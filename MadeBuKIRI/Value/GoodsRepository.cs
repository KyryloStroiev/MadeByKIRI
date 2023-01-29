namespace MadeByKIRI.Value;

public class GoodsRepository
{
	private readonly NewDbContext _context;
	public GoodsRepository(NewDbContext context) => _context = context;

	public async Task <List<Goods>> GetGoods() =>
		await _context.Goods.ToListAsync();

}
