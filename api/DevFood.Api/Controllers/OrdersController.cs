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

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _dbContext
                .Orders
                .Select(o => OrderModel.FromEntity(o))
                .ToList();

            return Ok(orders);
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

    public class OrderModel
    {
        public OrderModel(Guid id, DateTime createdAt, string status, decimal deliveryFee, decimal totalItemsPrice, Guid restaurantId, Guid customerId, int itemsCount)
        {
            Id = id;
            CreatedAt = createdAt;
            Status = status;
            DeliveryFee = deliveryFee;
            TotalItemsPrice = totalItemsPrice;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            ItemsCount = itemsCount;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalItemsPrice { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public int ItemsCount { get; set; }


        public static OrderModel FromEntity(Order order)
            => new OrderModel(order.Id, order.CreatedAt, order.Status.ToString(), order.DeliveryFee, order.TotalItemsPrice, order.RestaurantId, order.CustomerId, order.Items.Count);
    }
}
