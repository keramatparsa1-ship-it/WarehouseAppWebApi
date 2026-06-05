using Microsoft.EntityFrameworkCore;
using WarehouseApp.Domain.Entities;

namespace WarehouseApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // اضافه کردن جدول‌ها به دیتابیس
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // اینجا می‌توانید تنظیمات اضافی (مثل طول فیلدها) را بنویسید
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
    }
}
