using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Abstractions;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities;

namespace RetailAdminHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id=Guid.NewGuid(), Name="Product 1", Price=200, CreatedDate= DateTime.UtcNow, Stock=4},
            //    new() {Id=Guid.NewGuid(), Name="Product 2", Price=300, CreatedDate= DateTime.UtcNow, Stock=5},
            //    new() {Id=Guid.NewGuid(), Name="Product 3", Price=400, CreatedDate= DateTime.UtcNow, Stock=1241},
            //});
            //await _productWriteRepository.SaveAsync();
            Product p = await _productReadRepository.GetByIdAsync("27c4d0e2-0afc-4c48-af74-53f1713f3c03",false);
            p.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
