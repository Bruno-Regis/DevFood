namespace DevFood.Api.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(Guid productId, int quantity, decimal unitPrice, string observation)
        {
            ProductId = productId;
            Quantity = quantity;
            Observation = observation;
            TotalItemPrice = unitPrice * quantity;
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }
        public decimal TotalItemPrice { get; set; }
    }
}
