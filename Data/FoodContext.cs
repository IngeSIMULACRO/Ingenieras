using FoodSIMULACRO.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodSIMULACRO.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        public DbSet<Bebida> Bebidas => Set<Bebida>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bebida>(e =>
            {
                e.ToTable("Bebidas");
                e.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
                e.Property(p => p.Color).IsRequired().HasMaxLength(50);
                e.Property(p => p.Precio).HasPrecision(18, 2);
            });
        }
    }
}