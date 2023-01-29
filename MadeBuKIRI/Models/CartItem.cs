using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class CartItem
{
	[Key]
	public string ItemId { get; set; }

	public string CartId { get; set; }

	public int Quantity { get; set; }

	public System.DateTime DateCreated { get; set; }

	public int GoodsId { get; set; }

	public virtual Goods Goods { get; set; }

}
