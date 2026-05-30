
using Microsoft.EntityFrameworkCore;
using WarehouseAppWebApi.Data;
using Microsoft.AspNetCore.Builder;

namespace WarehouseAppWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();




            // اتصال به دیتابیس
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseDefaultFiles(); // اجازه استفاده از فایل index.html به عنوان صفحه اصلی
            app.UseStaticFiles();  // اجازه دسترسی به فایل‌های پوشه wwwroot

            app.MapControllers();

            app.Run();
        }
    }
}
