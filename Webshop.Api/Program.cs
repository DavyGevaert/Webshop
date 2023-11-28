using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Webshop.Api.Settings;
using Webshop.Repository;
using Webshop.Services;
using Webshop.Services.Abstractions;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);
builder.Services.AddSingleton(settings);

builder.Services.AddDbContext<WebshopDbContext>(options =>
{
	options.UseSqlServer(settings.ConnectionString);
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IItemService, ItemService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  builder =>
					  {
						  builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
					  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
