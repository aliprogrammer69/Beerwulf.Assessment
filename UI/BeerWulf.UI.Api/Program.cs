using BeerWulf.Bootstrapper.Extensions;
using BeerWulf.Common;
using BeerWulf.Common.Models;
using BeerWulf.Common.Utils;
using BeerWulf.UI.Api.Infra;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
                .AddBeerWolfApi(new ApiServiceCollectionManager())
                //.AddBeerWulfDbContext(opt => opt.UseSqlServer(builder.Configuration.GetSection("connectionString").Get<string>());
                .AddBeerWulfDbContext(opt => opt.UseInMemoryDatabase("BeerWulfDb"))
                .AddTransient<IConfigureOptions<MvcOptions>, JsonOutputFormatterSetup>();

var app = builder.Build();

app.Services.InitializeBeerWulfMockProducts(); // inorder to persist data in sql server, comment this line

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else {
    app.UseExceptionHandler(appError => {
        appError.Run(async context => {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            var serializer = context.RequestServices.GetService<ISerializer>();
            if (contextFeature != null) {
                Result errorResult = new Result(ResultCode.ServerError, "Internal Server Error Occurred. Please Call Provider!");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(serializer.Serialize(errorResult));
            }
        });
    });
}

app.MapControllers();

app.Run();