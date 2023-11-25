using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Webshop.UI.BlazorApp;
using Webshop.UI.BlazorApp.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);
builder.Services.AddSingleton(settings);

// https://learn.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-3.1&pivots=webassembly#packages
// Add nuget package Microsoft.Extensions.Http
// Add services to the container.
builder.Services.AddHttpClient("Webshop", options =>
{
    options.BaseAddress = new Uri(settings.ApiBaseUrl);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
