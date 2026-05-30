using Microsoft.EntityFrameworkCore;
using WarehouseAppWebApi.Models;

namespace WarehouseAppWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // این خط باعث می‌شود EF Core جدولی به نام Products در دیتابیس بسازد
        public DbSet<Product> Products { get; set; }
    }
}
