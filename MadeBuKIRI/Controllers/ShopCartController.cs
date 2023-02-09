

using Microsoft.EntityFrameworkCore;

namespace MadeByKIRI.Controllers;

public class ShopCartController : Controller
{
	private readonly IAllGoods _goodsRep;
	private readonly ShopCart _shopCart;
	private readonly NewDbContext _dbContext;

	public ShopCartController(IAllGoods goodsRep, ShopCart shopCart, NewDbContext dbConext)
	{
		_goodsRep = goodsRep;
		_shopCart = shopCart;
		_dbContext = dbConext;
	}
	public ViewResult Index()
	{
		var items = _shopCart.GetShopItem();
		_shopCart.ListShopItem = items;

		var obj = new ShopCartViewModel
		{
			shopCart = _shopCart
		};
		return View(obj);
	}
    
    public RedirectToActionResult AddToCarts(int goodsId)
	{
		var item = _goodsRep.Goods.FirstOrDefault(c => c.GoodsId == goodsId);
		if (item != null)
		{
			_shopCart.AddToCarts(item);
		}
		return RedirectToAction ("Index");
	}
	public async Task<IActionResult> DeleteGoods(int goodsid)
	{
		var goods = await _dbContext.ShopCartItem
			 .FirstOrDefaultAsync(dbgoods => dbgoods.IdItem == goodsid);
		if (goods != null)
		{
			_dbContext.ShopCartItem.Remove(goods);
			await _dbContext.SaveChangesAsync();
		}
		return RedirectToAction("Index");
	}


}

