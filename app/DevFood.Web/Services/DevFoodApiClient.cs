using DevFood.Web.Models;
using static System.Net.WebRequestMethods;

namespace DevFood.Web.Services
{
    public class DevFoodApiClient
    {
        private readonly HttpClient _http;
        public DevFoodApiClient(HttpClient http) => _http = http;

        public Task<List<CategoryModel>?> GetCategoriesAsync()
        => _http.GetFromJsonAsync<List<CategoryModel>>("api/categories");

        public Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryCommand command)
            => _http.PostAsJsonAsync("api/categories", command);

        public Task<List<RestaurantModel>?> GetRestaurantsAsync()
            => _http.GetFromJsonAsync<List<RestaurantModel>>("api/restaurants");

        public Task<HttpResponseMessage> CreateRestaurantAsync(CreateRestaurantCommand command)
            => _http.PostAsJsonAsync("api/restaurants", command);

        public Task<List<ProductModel>?> GetProductsAsync(Guid? restaurantId = null)
        {
            var url = restaurantId is null ? "api/products" : $"api/products?restaurantId={restaurantId}";
            return _http.GetFromJsonAsync<List<ProductModel>>(url);
        }

        public Task<HttpResponseMessage> CreateProductAsync(CreateProductCommand command)
            => _http.PostAsJsonAsync("api/products", command);

        public Task<List<CustomerModel>?> GetCustomersAsync()
            => _http.GetFromJsonAsync<List<CustomerModel>>("api/customers");

        public Task<HttpResponseMessage> CreateCustomerAsync(CreateCustomerCommand command)
            => _http.PostAsJsonAsync("api/customers", command);

        public Task<List<DeliveryPersonModel>?> GetDeliveryPersonsAsync()
            => _http.GetFromJsonAsync<List<DeliveryPersonModel>>("api/delivery-persons");

        public Task<HttpResponseMessage> CreateDeliveryPersonAsync(CreateDeliveryPersonCommand command)
            => _http.PostAsJsonAsync("api/delivery-persons", command);

        public Task<List<OrderModel>?> GetOrdersAsync(Guid? restaurantId)
        {
            var url = restaurantId is null ? "api/orders" : $"api/orders?restaurantId={restaurantId}";

            return _http.GetFromJsonAsync<List<OrderModel>>(url);
        }

        public Task<HttpResponseMessage> CreateOrderAsync(CreateOrderCommand command)
            => _http.PostAsJsonAsync("api/orders", command);

    }
}
