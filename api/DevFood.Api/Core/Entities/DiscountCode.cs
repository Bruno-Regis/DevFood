namespace DevFood.Api.Core.Entities
{
    public class DiscountCode : BaseEntity
    {
        public DiscountCode(string code, DateTime startDate, DateTime? expirationDate,  Guid restaurantId, decimal discountAmount, decimal minimumOrderAmount)
        {
            Code = code;
            StartDate = startDate;
            ExpirationDate = expirationDate;
            RestaurantId = restaurantId;
            DiscountAmount = discountAmount;
            MinimumOrderAmount = minimumOrderAmount;

            IsActive = true;
        }

        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public Guid RestaurantId { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinimumOrderAmount { get; set; }
    }
}
