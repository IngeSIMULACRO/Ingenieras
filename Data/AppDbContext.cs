using Microsoft.EntityFrameworkCore;
using FoodSIMULACRO.Models;

namespace FoodSIMULACRO.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Bebida> Bebidas => Set<Bebida>();

}



