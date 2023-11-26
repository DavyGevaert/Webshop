using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Webshop.Sdk.Abstractions;
using static System.Net.Mime.MediaTypeNames;
using Webshop.Model;

namespace Webshop.Sdk
{
    public class BlurayApi : IBlurayApi
    {
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0

        private readonly IHttpClientFactory _httpClientFactory;

        public BlurayApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Bluray> GetAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/Blurays/Get?id={id}";   // zelfde als route in Swagger UI

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<Bluray>();

            if (result is null)
            {
                return new Bluray();
            }

            return result;
        }

        public async Task<IList<Bluray>> FindAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = "/Blurays/Find";   // zelfde als route in Swagger UI

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<IList<Bluray>>();

            if (result is null)
            {
                return new List<Bluray>();
            }

            return result;
        }

        public async Task CreateItemAsync(Bluray blurayResult)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = "/Blurays/Create";   // zelfde als route in Swagger UI

            var blurayJson = new StringContent(JsonSerializer.Serialize(blurayResult), Encoding.UTF8, Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage = await httpClient.PostAsync(route, blurayJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task SaveItemAsync(Bluray blurayResult)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/Blurays/Update/{blurayResult.Id}";   // zelfde als route in Swagger UI

            var blurayJson = new StringContent(JsonSerializer.Serialize(blurayResult), Encoding.UTF8, Application.Json);

            var httpResponseMessage = await httpClient.PutAsync(route, blurayJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteItemAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/Blurays/Delete?id={id}";   // zelfde als route in Swagger UI

            using var httpResponseMessage = await httpClient.DeleteAsync(route);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
