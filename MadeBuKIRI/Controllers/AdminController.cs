using MadeByKIRI.Models;
using MadeByKIRI.Value;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace HW35MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private NewDbContext _dbContext;
        private readonly GoodsRepository _repository;

		 public List<Login> MockUsers = new()
	     {
		    new Login { Id = 1, UserName = "User", Password = "1111", Role = "Admin" },
		    new Login { Id = 2, UserName = "user2", Password = "pass2", Role = "Support" },
		    new Login { Id = 3, UserName = "user3", Password = "pass3", Role = "Otherrole" }
	     };

		public AdminController(ILogger<AdminController> logger, NewDbContext context, 
            GoodsRepository repository)
        {
            _logger = logger;
            _dbContext = context;
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Goods>>> ShowGoods()
        {
			var goods = await _repository.GetGoods();
           return View(goods);
		}
          
        public async Task<ActionResult<List<Buyers>>> ShowBuyer() =>
           View(await _dbContext.Buyers.ToListAsync());
        public async Task<ActionResult<List<Order>>> Admin() =>
           View(await _dbContext.Order.Include(p => p.Buyers).Include(p => p.Goods).ToListAsync());
        //public ActionResult ShowUsersDi()
        //{
        //	if (User.IsInRole("Admin")) return RedirectToAction("Admin");
        //	return View();
        //}
        [AllowAnonymous]
        public ActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            
            var dbUser = MockUsers
                .FirstOrDefault(userLogin => userLogin.UserName == login.UserName &&
                                             userLogin.Password == login.Password);

            if (dbUser is not null)
            {
                _logger.LogInformation($"User {dbUser.UserName} has signed in");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(
                        new List<Claim>
                        {
                        new(ClaimsIdentity.DefaultNameClaimType, dbUser.UserName),
                        new(ClaimsIdentity.DefaultRoleClaimType, dbUser.Role)
                        },
                        "applicationCookie",
                        ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType))
                );
            }
            else _logger.LogError($"Invalid login {login.UserName} & {login.Password}");

            return RedirectToAction("/Home/Home");
        }
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home/Home");
        }
        [HttpGet]
        public async Task<ActionResult<Goods>> EditGoods(int Id) =>
            View(await _dbContext.Goods.FirstOrDefaultAsync(u => u.GoodsId == Id));

        [HttpPost]
        public async Task<IActionResult> EditGoods (Goods goods)
        {
            _dbContext.Entry(await _dbContext.Goods
                .FirstOrDefaultAsync(dbgoods => dbgoods.GoodsId == goods.GoodsId))
                .CurrentValues.SetValues(goods);
            await _dbContext.SaveChangesAsync(); 
            await UploadImage(goods.GoodsId, Request);
            return RedirectToAction("ShowGoods");
        }
        public ActionResult CreateGoods()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateGoods(Goods goods)
        {
            var newgoods = await _dbContext.Goods
                .AllAsync(dbgoods => dbgoods.GoodsId != goods.GoodsId)
                 ? new Goods(goods) : null;
            _ = _dbContext.Set<Goods>().AddAsync(newgoods!);
            await _dbContext.SaveChangesAsync();


            return RedirectToAction("ShowGoods");
        }
        public ActionResult CreateBuyers()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateBuyers(Buyers buyers)
        {
            var newbuyers= await _dbContext.Buyers
                .AllAsync(dbbuyer => dbbuyer.IDBuyers != buyers.IDBuyers)
                 ? new Buyers (buyers) : null;
            _ = _dbContext.Set<Buyers>().AddAsync(newbuyers!);
            await _dbContext.SaveChangesAsync();


            return RedirectToAction("ShowBuyer");
        }
        

        public async Task<IActionResult> DeleteGoods (int goodsid)
        {
            var goods = await _dbContext.Goods
                 .FirstOrDefaultAsync(dbgoods => dbgoods.GoodsId == goodsid);
            if (goods !=null)
            {
                _dbContext.Goods.Remove(goods);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ShowGoods");
        }
        public async Task<IActionResult> DeleteBuyer(int buyerid)
        {
            var buyer = await _dbContext.Buyers
                 .FirstOrDefaultAsync(dbbuyer => dbbuyer.IDBuyers == buyerid);
            if (buyer != null)
            {
                _dbContext.Buyers.Remove(buyer);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ShowBuyer");
        }
        [HttpGet]
        public async Task<ActionResult<Buyers>> EditBuyer(int? Id) =>
          View(await _dbContext.Buyers.FirstOrDefaultAsync(u => u.IDBuyers == Id));

        [HttpPost]
        public async Task<IActionResult> EditBuyer(int id)
        {
            _dbContext.Entry(await _dbContext.Buyers
                .FirstOrDefaultAsync(dbbuyer => dbbuyer.IDBuyers == dbbuyer.IDBuyers))
                .CurrentValues.SetValues(id);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ShowBuyer");
        }

        public IActionResult DeleteFile (string filePath)
        {
            var goodsId = filePath.Split("-").First();
            var fullpath = $"{BasePath}/images/goods/{filePath}";
            if(System.IO.File.Exists(fullpath))
               System.IO.File.Delete(fullpath);
            return RedirectToAction("EditGoods", new { id = goodsId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}