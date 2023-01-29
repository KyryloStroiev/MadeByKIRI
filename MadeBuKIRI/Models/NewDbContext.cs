using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace MadeByKIRI.Models;

public class NewDbContext : DbContext
{
    public DbSet<Buyers> Buyers { get; set; }
    public DbSet<Goods> Goods { get; set; }
    public DbSet<Order> Order { get; set; }
    
    public NewDbContext(DbContextOptions<NewDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Order>()
         .HasKey(t => new { t.BuyersId, t.GoodsId });

        modelBuilder.Entity<Order>()
            .HasOne(pt => pt.Buyers)
            .WithMany(p => p.Order)
            .HasForeignKey(pt => pt.BuyersId);

        modelBuilder.Entity<Order>()
            .HasOne(pt => pt.Goods)
            .WithMany(t => t.Order)
            .HasForeignKey(pt => pt.GoodsId);




    }

}