using DevFood.Api.Core.Enums;

namespace DevFood.Api.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(string title, string description, string? photoUrl, ProductTypeEnum productType, decimal price, Guid restaurantId)
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
        public ProductTypeEnum ProductType { get; set; }
        public decimal Price { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
