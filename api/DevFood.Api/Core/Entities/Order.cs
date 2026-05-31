using DevFood.Api.Core.Enums;

namespace DevFood.Api.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order(decimal deliveryFee, List<OrderItem> items, Guid restaurantId, Guid customerId)
        {
            DeliveryFee = deliveryFee;
            Items = items;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            TotalItemsPrice = deliveryFee + items.Sum(i => i.TotalItemPrice);
            Status = OrderStatusEnum.Requested;
            Messages = [];
            History = [];
        }
        public decimal DeliveryFee { get; set; }
        public decimal TotalItemsPrice { get; set; }
        public List<OrderItem> Items { get; set; }
        public List<OrderHistory> History { get; set; }
        public List<OrderMessage> Messages { get; set; }
        public OrderReview? Review { get; set; }
        public OrderStatusEnum Status { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid? DeliveryPersonId { get; set; }
        public Guid CustomerId { get; set; }

        public void SetDeliveryPerson(Guid deliveryPersonId)
        {
            DeliveryPersonId = deliveryPersonId;
        }

        public void AcceptOrder()
        {

            if (Status != OrderStatusEnum.Requested)
            {
                throw new InvalidOperationException("Only orders with status 'Requested' can be accepted.");
            }

            Status = OrderStatusEnum.Processing;
        }

        public void SetReadyForDelivery()
        {
            if (Status != OrderStatusEnum.Processing)
            {
                throw new InvalidOperationException("Only orders with status 'Processing' can be set as ready for delivery.");
            }
            Status = OrderStatusEnum.ReadyForDelivery;
        }

        public void SetInTransit()
        {
            if (Status != OrderStatusEnum.ReadyForDelivery)
            {
                throw new InvalidOperationException("Only orders with status 'ReadyForDelivery' can be set as in transit.");
            }
            Status = OrderStatusEnum.Intransit;
        }


    }
}
