using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Webshop.Sdk.Abstractions;
using Webshop.Services.Model.Core;
using Webshop.Services.Model.Results;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;

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

        public async Task<ServiceResult<BlurayResult>> GetAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = $"/blurays/Get?id={id}";   // zelfde als route in Swagger UI

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<BlurayResult>>();

            if (result is null)
            {
                return new ServiceResult<BlurayResult>();
            }

            return result;
        }

        public async Task<ServiceResult<IList<BlurayResult>>> FindAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var route = "/blurays/Find";

            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResult<IList<BlurayResult>>>();

            if (result is null)
            {
                return new ServiceResult<IList<BlurayResult>>();
            }

            return result;
        }

        public async Task CreateItemAsync(BlurayResult blurayResult)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var blurayJson = new StringContent(JsonSerializer.Serialize(blurayResult), Encoding.UTF8, Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage = await httpClient.PostAsync("/api/TodoItems", blurayJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task SaveItemAsync(BlurayResult blurayResult)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            var blurayJson = new StringContent(JsonSerializer.Serialize(blurayResult), Encoding.UTF8, Application.Json);

            var httpResponseMessage = await httpClient.PutAsync($"/api/TodoItems/{blurayResult.Id}", blurayJson);

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task DeleteItemAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("Webshop");

            using var httpResponseMessage = await httpClient.DeleteAsync($"/api/TodoItems/{id}");

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
