
namespace MadeByKIRI.Controllers;

public class OrderController : Controller
{
	private readonly NewDbContext _context;
	private readonly IAllOrders _allOrders;
	private readonly ShopCart _shopCart;

	public OrderController(NewDbContext context, ShopCart shopCart, IAllOrders allOrders)
	{
		_allOrders = allOrders;
		_shopCart = shopCart;
		_context = context;
	}
    public async Task<IActionResult> DeleteOrder(int orderid)
	{
        var order= await _context.OrderDetail
             .FirstOrDefaultAsync(dborder => dborder.Id == orderid);
		if (order != null)
		{
            _context.OrderDetail.Remove(order);
            await _context.SaveChangesAsync();
        }
        return Redirect("~/Admin/Admin");
    }
    public async Task <ActionResult<Order>> CheckOut(int? id)
	{
		return View(await _context.Order.FirstOrDefaultAsync(c=>c.Id == id));
	}
	[HttpPost]
	public async Task <IActionResult> CheckOut(Order order)
	{
		_shopCart.ListShopItem = _shopCart.GetShopItem();

		_allOrders.createOrder(order);
		return RedirectToAction("Complete");
    }


		

		public IActionResult Complete()
	    {
		  ViewBag.Message = "Order accepted";
		  return View("Complete");
	    }
}