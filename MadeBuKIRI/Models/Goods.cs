namespace MadeByKIRI.Models;

public class Goods : GoodsModel
{
	public virtual List<OrderDetail> OrderDetail { get; set; }
	public virtual ShopCartItem ShopCartItem { get; set; }
    //public virtual List<Category> Category { get; set; }

    public Goods() { }

    public Goods (GoodsModel goodsmodel)
    {
        GoodsId = goodsmodel.GoodsId;
        NameGoods = goodsmodel.NameGoods;
        Article = goodsmodel.Article;
        Price = goodsmodel.Price;
        Available = goodsmodel.Available;
        Info = goodsmodel.Info;
    }
   
}
