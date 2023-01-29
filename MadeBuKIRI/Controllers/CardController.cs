//using MadeByKIRI.Models;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using System.Security.Claims;


//namespace HW35MVC.Controllers
//{

//	public class CardController : Controller

//	{
//		public ViewResult Index(string returnUrl)
//		{
//			return View(new CartIndexViewModel
//			{
//				Cart = GetCart(),
//				ReturnUrl = returnUrl
//			});
//		}
//		private readonly ILogger<CardController> _logger;
//		private NewDbContext _dbContext;

//		public CardController(ILogger<CardController> logger, NewDbContext context)
//		{
//			_logger = logger;
//			_dbContext = context;
//		}


//		public RedirectToRouteResult AddToCart(int goodsId, string returnUrl)
//		{
//			Goods goods = _dbContext.Goods
//				.FirstOrDefault(g => g.GoodsId == goodsId);

//			if (goods != null)
//			{
//				GetCart().AddItem(goods, 1);
//			}
//			return RedirectToAction("Index", new { returnUrl });
//		}

//		public RedirectToRouteResult RemoveFromCart(int goodsId, string returnUrl)
//		{
//			Goods goods = _dbContext.Goods
//				.FirstOrDefault(g => g.GoodsId == goodsId);

//			if (goods != null)
//			{
//				GetCart().RemoveLine(goods);
//			}
//			return RedirectToAction("Index", new { returnUrl });
//		}

//		public Cart GetCart()
//		{
//			Cart cart = (Cart)Session["Cart"];
//			if (cart == null)
//			{
//				cart = new Cart();
//				Session["Cart"] = cart;
//			}
//			return cart;
//		}
//	}
//}