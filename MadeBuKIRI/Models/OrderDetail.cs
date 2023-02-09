namespace MadeByKIRI.Models;

public class OrderDetail
{
	[Key] public int Id { get; set; }
	public int OrderId { get; set; }
	public int GoodsId { get; set; }
	public int Price { get; set; }
	public virtual Goods Goods { get; set; }
	public virtual Order Order { get; set; }
}
