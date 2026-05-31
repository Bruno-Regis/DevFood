namespace DevFood.Api.Core.Entities
{
    public class Restaurant : BaseEntity
    {
        public Restaurant(string title, string description, string address, List<Guid> categories, decimal? minimumOrderAmount)
        {
            Title = title;
            Description = description;
            Address = address;
            Categories = [];
            DiscountCodes = [];
            Categories = categories.Select(c => new RestaurantCategory(Id, c)).ToList();
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
