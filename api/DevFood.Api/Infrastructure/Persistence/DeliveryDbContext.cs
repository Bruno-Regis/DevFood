using DevFood.Api.Core.Entities;

namespace DevFood.Api.Infrastructure.Persistence
{
    public class DeliveryDbContext
    {
        public DeliveryDbContext()
        {
            Categories = [];
            Restaurants = [];
            Products = [];
            Customers = [];
            Orders = [];
            DeliveryPersons = [];
        }

        public List<Category> Categories { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public List<DeliveryPerson> DeliveryPersons { get; set; }
    }
}
