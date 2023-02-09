
namespace KIRI.Domen.Repository;

public class OrdersRepository : IAllOrders
{
	private readonly NewDbContext _appDbContext;
	private readonly ShopCart _shopCart;

	public OrdersRepository(NewDbContext appDbContext, ShopCart shopCart)
	{
		_appDbContext = appDbContext;
		_shopCart = shopCart;
	}

    public void createOrder(Order order)
    {
        order.OrderTime = DateTime.Now;
        _appDbContext.Order.Add(order);
        _appDbContext.SaveChanges();
        var items = _shopCart.ListShopItem;

        foreach (var element in items)
        {
            var orderDetail = new OrderDetail()
            {
                GoodsId = element.Goods.GoodsId,
                OrderId = order.Id,
                Price = element.Goods.Price
            };
            _appDbContext.OrderDetail.Add(orderDetail);
        }
        _appDbContext.SaveChanges();
    }
}
