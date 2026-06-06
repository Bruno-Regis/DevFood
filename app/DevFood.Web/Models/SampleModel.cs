using static MudBlazor.Icons;

namespace DevFood.Web.Models
{
    public class SampleModel
    {
    }

    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }


    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class DeliveryPersonModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
    }


    public class OrderModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalItemsPrice { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public int ItemCount { get; set; }
    }

    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? PhotoUrl { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public Guid RestaurantId { get; set; }
    }

    public class RestaurantModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Guid> Categories { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
    }

    public class CreateCategoryCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CreateCustomerCommand
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Today.AddYears(-25);
        public string Document { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class CreateDeliveryPersonCommand
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Today.AddYears(-25);
        public string Document { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }

    public class CreateOrderCommand
    {
        public decimal DeliveryFee { get; set; }
        public List<OrderItemCommandModel> Items { get; set; } = [];
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
    }

    public class OrderItemCommandModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public string Observation { get; set; } = string.Empty;
    }

    public enum ProductType
    {
        Food = 1,
        Drink = 2,
        Desert = 3
    }

    public class CreateProductCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public int Type { get; set; } = (int)ProductType.Food;
        public decimal Price { get; set; }
        public Guid RestaurantId { get; set; }
    }

    public class CreateRestaurantCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Guid> Categories { get; set; } = [];
        public decimal? MininumOrderAmount { get; set; }
    }
}
