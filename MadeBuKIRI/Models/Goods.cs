namespace MadeByKIRI.Models;

public class Goods : GoodsModel
{
	public virtual OrderDetail OrderDetail { get; set; }
	public virtual ShopCartItem ShopCartItem { get; set; }

	public Goods() { }

    public Goods (GoodsModel goodsmodel)
    {
        GoodsId = goodsmodel.GoodsId;
        NameGoods = goodsmodel.NameGoods;
        Article = goodsmodel.Article;
        Price = goodsmodel.Price;
        Available = goodsmodel.Available;
        isFavourite = goodsmodel.isFavourite;
        Info = goodsmodel.Info;
    }
   
}
