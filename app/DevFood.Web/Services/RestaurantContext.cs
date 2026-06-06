using DevFood.Web.Models;

namespace DevFood.Web.Services
{
    public class RestaurantContext
    {
        private Guid? _selectedRestaurantId;
        private RestaurantModel? _selectedRestaurant;

        public Guid? SelectedRestaurantId => _selectedRestaurantId;
        public RestaurantModel? SelectedRestaurant => _selectedRestaurant;

        public event Action? OnChange;

        public void Set(RestaurantModel? restaurant)
        {
            _selectedRestaurant = restaurant;
            _selectedRestaurantId = restaurant?.Id;
            OnChange?.Invoke();
        }

        public void Clear() => Set(null);
    }
}
