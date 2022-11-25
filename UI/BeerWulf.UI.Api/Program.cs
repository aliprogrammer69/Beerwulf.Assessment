using BeerWulf.Bootstrapper.Extensions;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
                .AddBeerWolfApi()
                .AddBeerWulfDbContext(opt => opt.UseSqlServer("data source=.;initial catalog=BeerWulfDb;integrated security = true;Encrypt=false;"));
                //.AddBeerWulfDbContext(opt => opt.UseInMemoryDatabase("BeerWulfDb"));

var app = builder.Build();
//app.Services.InitializeBeerWulfMockProducts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
