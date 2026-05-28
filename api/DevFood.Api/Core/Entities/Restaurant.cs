namespace DevFood.Api.Core.Entities
{
    public class Restaurant : BaseEntity
    {
        public Restaurant(string title, string description, string address, Guid categoryId, int myProperty, decimal? minimumOrderAmount)
        {
            Title = title;
            Description = description;
            Address = address;
            CategoryId = categoryId;
            Categories = [];
            DiscountCodes = [];
            MyProperty = myProperty;
            MinimumOrderAmount = minimumOrderAmount;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid CategoryId { get; set; }
        public List<RestaurantCategory> Categories { get; set; }
        public List<DiscountCode> DiscountCodes { get; set; }
        public int MyProperty { get; set; }
        public decimal? MinimumOrderAmount { get; set; }

    }
}
