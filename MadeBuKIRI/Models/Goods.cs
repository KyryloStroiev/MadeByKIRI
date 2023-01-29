namespace MadeByKIRI.Models;

public class Goods : GoodsModel
{
    public int BuyerId { get; set; }
    //public Buyers Buyers { get; set; }
    public List<Order> Order { get; set; }
    public Goods() { }

    public Goods (GoodsModel goodsmodel)
    {
        GoodsId = goodsmodel.GoodsId;
        NameGoods = goodsmodel.NameGoods;
        Article = goodsmodel.Article;
        Price = goodsmodel.Price;
        Quantity = goodsmodel.Quantity;
        Info = goodsmodel.Info;
    }
   
}
