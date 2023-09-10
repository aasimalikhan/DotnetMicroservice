using Mango.Services.PracticeCouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.PracticeCouponAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Shoe> Shoes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Shoe>().HasData(new Shoe
			{
				ShoeId = 1,
				ShoeBrand = "adidas",
				ShoePrice = 1200,
				ShoeSalePrice = 1000
			});

			modelBuilder.Entity<Shoe>().HasData(new Shoe
			{
				ShoeId = 2,
				ShoeBrand = "adidas",
				ShoePrice = 1300,
				ShoeSalePrice = 1200
			});
		}
	}
}
