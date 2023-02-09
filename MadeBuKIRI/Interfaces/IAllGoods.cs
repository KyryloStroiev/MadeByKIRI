

namespace MadeByKIRI.Interfaces;

public interface IAllGoods
{
	IEnumerable<Goods> Goods { get; }

	
	Goods GetObjectGoods(int goodsId);
}
