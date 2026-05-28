using DevFood.Api.Core.Enums;

namespace DevFood.Api.Core.Entities
{
    public class OrderReview : BaseEntity
    {
        public OrderReview(Guid orderId, Guid customerId, string text, int rating)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Text = text;
            Rating = rating;
        }

        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public OrderReviewStatusEnum Status { get; set; }
    }
}
