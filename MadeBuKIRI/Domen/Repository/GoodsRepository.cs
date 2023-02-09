
namespace KIRI.Domen.Repository;

public class GoodsRepository:  IAllGoods
{
	private readonly NewDbContext _appDBContext;

	public GoodsRepository(NewDbContext appDBContext)
	{
		_appDBContext = appDBContext;
	}

	public IEnumerable<Goods> Goods => _appDBContext.Goods;




	public Goods GetObjectGoods(int goodsId) => _appDBContext.Goods.FirstOrDefault(p => p.GoodsId == goodsId);
}
