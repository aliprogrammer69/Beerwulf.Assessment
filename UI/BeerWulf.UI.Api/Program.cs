using BeerWulf.Bootstrapper.Extensions;
using BeerWulf.Common.Utils;
using BeerWulf.UI.Api;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
                .AddBeerWolfApi(new ApiServiceCollectionManager())
                //.AddBeerWulfDbContext(opt => opt.UseSqlServer(builder.Configuration.GetSection("connectionString").Get<string>());
                .AddBeerWulfDbContext(opt => opt.UseInMemoryDatabase("BeerWulfDb"));

var app = builder.Build();

app.Services.InitializeBeerWulfMockProducts(); // inorder to persist data in sql server, comment this line

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
