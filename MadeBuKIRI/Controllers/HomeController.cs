
namespace MadeByKIRI.Controllers;

public class HomeController : Controller
{
    private readonly IAllGoods _allGoods;
  
    private readonly ILogger<HomeController> _logger;
    private NewDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, NewDbContext context, IAllGoods goodsRep)
    {
        _allGoods = goodsRep;
        _logger = logger;
        _dbContext = context;
    }
  
    public IActionResult Home()
    {
        return View();
    }
	
		public async Task<ActionResult<Goods>> Wallets()
    {
        return View(await _dbContext.Goods.ToListAsync());
    }
    public async Task<ActionResult<Goods>> Bags()
    {
        return View(await _dbContext.Goods.ToListAsync());
    }
    public async Task<ActionResult<Goods>> Backpacks()
    {
        return View(await _dbContext.Goods.ToListAsync());
    }
    public async Task<ActionResult<Goods>> Belts()
    {
        return View(await _dbContext.Goods.ToListAsync());
    }
    public async Task<ActionResult<Goods>> CardGoods(int id)
    {
        return View(await _dbContext.Goods.FirstAsync(goods => goods.GoodsId == id));
    }
    public async Task<ActionResult<Goods>> SmallGoods()
    {
        return View(await _dbContext.Goods.ToListAsync());
    }
    public IActionResult Contacts()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}