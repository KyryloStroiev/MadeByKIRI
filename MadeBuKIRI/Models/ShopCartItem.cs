
namespace MadeByKIRI.Models;

public class ShopCartItem
{
	[Key] public int IdItem{ get; set; }
	public Goods Goods { get; set; }
	public int Price { get; set; }
	public string ShopCartId { get; set; }
}