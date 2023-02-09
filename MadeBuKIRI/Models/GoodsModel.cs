using System.ComponentModel.DataAnnotations;

namespace MadeByKIRI.Models;

public class GoodsModel
{
    public int GoodsId { get; set; }
    public string? NameGoods { get; set; }
    public string? Article { get; set; }
    public int Price { get; set; }
    public string? Info { get; set; }
	public bool  Available { get; set; }
    public bool isFavourite { get; set; }

}
