using DevFood.Api.Core.Entities;
using DevFood.Api.Core.Enums;
using DevFood.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFood.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        
        private readonly DeliveryDbContext _dbContext;
        public ProductsController(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create(CreateProductCommand command)
        {
            var product = new Product(command.Title, command.Description, command.PhotoUrl, (ProductTypeEnum)command.ProductType, command.Price, command.RestaurantId);
            
            _dbContext.Products.Add(product);
            return Ok(product.Id);
        }
    }

    public class CreateProductCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public int ProductType { get; set; }
        public decimal Price { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
