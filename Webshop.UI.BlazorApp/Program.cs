using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Webshop.Sdk;
using Webshop.UI.BlazorApp;
using Webshop.UI.BlazorApp.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);

builder.Services.AddHttpClient("Webshop", options =>
{
    options.BaseAddress = new Uri(settings.ApiBaseUrl);
});

builder.Services.AddTransient<ItemApi>();
builder.Services.AddScoped<CartState>();

await builder.Build().RunAsync();
