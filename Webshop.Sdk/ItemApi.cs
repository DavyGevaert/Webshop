using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Webshop.Sdk.Abstractions;
using static System.Net.Mime.MediaTypeNames;
using Webshop.Model;

namespace Webshop.Sdk
{
    public class ItemApi : IItemApi
    {
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0

        private readonly IHttpClientFactory _httpClientFactory;

        public ItemApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Item> GetAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/Items/Get?id={id}";   // zelfde als route in Swagger UI

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<Item>();

            if (result is null)
            {
                return new Item();
            }

            return result;
        }

        public async Task<IList<Item>> FindAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = "/Items/Find";   // zelfde als route in Swagger UI

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<List<Item>>();

            if (result is null)
            {
                return new List<Item>();
            }

            return result;
        }

        public async Task CreateItemAsync(Item item)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = "/Items/Create";   // zelfde als route in Swagger UI

            var itemJson = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage = await httpClient.PostAsync(route, itemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task SaveItemAsync(Item item)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/Items/Update/{item.Id}";   // zelfde als route in Swagger UI

            var itemJson = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, Application.Json);

            var httpResponseMessage = await httpClient.PutAsync(route, itemJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteItemAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/Items/Delete?id={id}";   // zelfde als route in Swagger UI

            using var httpResponseMessage = await httpClient.DeleteAsync(route);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
