using Microsoft.AspNetCore.Mvc;
using WarehouseApp.Application.Interfaces;
using WarehouseApp.Application.DTOs;
using WarehouseApp.Domain.Entities;

namespace WarehouseApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name ?? ""
            });

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _productRepository.GetByIdAsync(id);

            if (p == null)
                return NotFound();

            var dto = new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name ?? ""
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                SKU = dto.SKU,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            await _productRepository.AddAsync(product);

            dto.Id = product.Id;

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto dto)
        {
            var existing = await _productRepository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.SKU = dto.SKU;
            existing.Description = dto.Description;
            existing.Price = dto.Price;
            existing.CategoryId = dto.CategoryId;

            await _productRepository.UpdateAsync(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _productRepository.DeleteAsync(existing);

            return NoContent();
        }
    }
}
