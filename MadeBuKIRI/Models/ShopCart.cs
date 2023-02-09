
namespace MadeByKIRI.Models;

public class ShopCart 
{
	private readonly NewDbContext _appDBContext;

	public ShopCart(NewDbContext appDBContext)
	{
		_appDBContext = appDBContext;
	}
	public string ShopCartId { get; set; }

	public List<ShopCartItem> ListShopItem { get; set; }

	public static ShopCart GetCart(IServiceProvider service)
	{
		ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
		var context = service.GetService<NewDbContext>();
		string shopCartId = session.GetString("GoodsId") ?? Guid.NewGuid().ToString();
		session.SetString("GoodsId", shopCartId);

		return new ShopCart(context) { ShopCartId = shopCartId };
	}

	public void AddToCarts(Goods goods)
	{
		_appDBContext.ShopCartItem.Add(new ShopCartItem
		{
			ShopCartId = ShopCartId,
			Goods = goods,
			Price = goods.Price

		}); ;
		_appDBContext.SaveChanges();
	}

	public List<ShopCartItem> GetShopItem()
	{
		return _appDBContext.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Goods).ToList();
	}
}