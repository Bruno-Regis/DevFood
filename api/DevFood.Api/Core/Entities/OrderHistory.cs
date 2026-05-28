namespace DevFood.Api.Core.Entities
{
    public class OrderHistory : BaseEntity
    {
        public OrderHistory(string statusUpdate, Guid orderId)
        {
            StatusUpdate = statusUpdate;
            OrderId = orderId;
        }

        public string StatusUpdate { get; set; }
        public Guid OrderId { get; set; }
    }
}
