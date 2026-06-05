using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseApp.Domain.Entities;
using WarehouseApp.Infrastructure.Persistence;

namespace WarehouseApp.WebApi.Controllers;

[ApiController] 
[Route("api/[controller]")] 
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return Ok(category);
    }
}
