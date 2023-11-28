using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Webshop.Sdk;
using Webshop.UI.BlazorApp;
using Webshop.UI.BlazorApp.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);
builder.Services.AddSingleton(settings);

// https://learn.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-3.1&pivots=webassembly#packages
// Add services to the container.
builder.Services.AddHttpClient("Webshop", options =>
{
    options.BaseAddress = new Uri(settings.ApiBaseUrl);
});

builder.Services.AddTransient<ItemApi>();
builder.Services.AddScoped<CartState>();    // this has to be addscoped, if it is addtransient the cart will not show simply because the SelectedItems generate a new instance when going to the cart page

await builder.Build().RunAsync();
