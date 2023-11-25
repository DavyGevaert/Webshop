using Webshop.Repository;
using Webshop.Services;
using Webshop.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebshopDbContext>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IBlurayService, BlurayService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
