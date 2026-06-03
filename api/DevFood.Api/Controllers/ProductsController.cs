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

        // api/products?restaurantId=123
        [HttpGet]
        public IActionResult GetAll(Guid restaunrantId)
        {
            var products = _dbContext.Products
                .Where(p => p.RestaurantId == restaunrantId)
                .Select(p => ProductModel.FromEntity(p))
                .ToList();
            return Ok(products);
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

    public class ProductModel
    {
        public ProductModel(string title, string description, string? photoUrl, string productType, decimal price, Guid restaurantId)
        {
            Title = title;
            Description = description;
            PhotoUrl = photoUrl;
            ProductType = productType;
            Price = price;
            RestaurantId = restaurantId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string? PhotoUrl { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public Guid RestaurantId { get; set; }

        public static ProductModel FromEntity(Product product)
            => new ProductModel(product.Title, product.Description, product.PhotoUrl, product.ProductType.ToString(), product.Price, product.RestaurantId
            );
    }
}
