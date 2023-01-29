using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class GoodsModel
{
    public int GoodsId { get; set; }
    public string? NameGoods { get; set; }
    public string? Article { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Info { get; set; }


}
