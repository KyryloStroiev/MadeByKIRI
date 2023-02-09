using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace MadeByKIRI.Models;

public class NewDbContext : DbContext
{
    public DbSet<ShopCartItem> ShopCartItem { get; set; }
    public DbSet<Goods> Goods { get; set; }
	public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Order> Order { get; set; }
    
    public NewDbContext(DbContextOptions<NewDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

		modelBuilder.Entity<ShopCartItem>()
					.HasOne(p => p.Goods)
					.WithOne(p => p.ShopCartItem)
					.HasForeignKey<ShopCartItem>(b => b.IdItem);

		modelBuilder.Entity<OrderDetail>()
			.HasOne(goods => goods.Goods)
			.WithOne(goods => goods.OrderDetail)
			.HasForeignKey<OrderDetail>(goods => goods.GoodsId);
		modelBuilder.Entity<OrderDetail>()
			.HasOne(order => order.Order)
			.WithMany(order => order.OrderDetail)
			.HasForeignKey(order => order.OrderId);




	}

}