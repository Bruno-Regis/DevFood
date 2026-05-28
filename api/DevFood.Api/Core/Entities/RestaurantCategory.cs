namespace DevFood.Api.Core.Entities
{
    public class RestaurantCategory : BaseEntity
    {
        public RestaurantCategory(Guid restaurantId, Guid categoryId)
        {
            RestaurantId = restaurantId;
            CategoryId = categoryId;
        }

        public Guid RestaurantId { get; set; }
        public Guid CategoryId { get; set; }


    }
}
