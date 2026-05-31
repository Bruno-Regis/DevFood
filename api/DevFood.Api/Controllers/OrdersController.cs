using DevFood.Api.Core.Entities;
using DevFood.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace DevFood.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly DeliveryDbContext _dbContext;
        public OrdersController(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Create(CreateOrderCommand command)
        {
            var items = new List<OrderItem>();

            foreach (var item in command.Items) // CHECAR SE NÃO IRÁ QUEBRAR
            {
                var product = _dbContext.Products.SingleOrDefault(p => p.Id == item.ProductId);

                if (product != null)
                    items.Add(new OrderItem(product.Id, item.Quantity, product.Price, item.Observation));
            }   

            var order = new Order(command.DeliveryFee, items, command.RestaurantId, command.CustomerId);
            
            _dbContext.Orders.Add(order);
            return Ok(order.Id);
        }
    }

    public class CreateOrderCommand
    {
        public decimal DeliveryFee { get; set; }
        public List<OrderItemCommandModel> Items { get; set; } = [];
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
    }

    public class  OrderItemCommandModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; } = string.Empty;
    }
}
