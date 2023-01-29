using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime DateOrder { get; set; }
    public int BuyersId { get; set; }
    public Buyers Buyers { get; set; }
    public int GoodsId { get; set; }
    public Goods Goods { get; set; }
}
