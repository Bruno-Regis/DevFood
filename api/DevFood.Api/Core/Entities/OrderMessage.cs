namespace DevFood.Api.Core.Entities
{
    public class OrderMessage : BaseEntity
    {
        public OrderMessage(Guid customerId, Guid orderId, string text)
        {
            CustomerId = customerId;
            OrderId = orderId;
            Text = text;
        }

        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public string Text { get; set; }
    }
}
