using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using ProductsAPI.APIDomain;
using ProductsAPI.Controllers;
using ProductsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddLogging();
builder.Services.AddFeatureManagement();
builder.Services.AddSingleton<IProductService, ProductService>(x => new ProductService(BuildProductList()));
builder.Services.AddScoped<ICompleteOrderService, CompleteOrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// allow all through
app.UseCors(x =>  x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// only allow this website through
//app.UseCors(x => x.WithOrigins("http://127.0.0.1:5500")
//                .AllowAnyMethod()
//                .AllowAnyHeader());
//Console.WriteLine("Only allowing from http://127.0.0.1:5500/");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


List<Product> BuildProductList()
{
    return new List<Product> {
       new Product()
       {
           Id = 1, 
           Name = "90x90 Pine Post", 
           Description = "Pine Posts - Construction", 
           unitPrice = 1960, 
           EffectiveFrom = DateTimeOffset.Parse("01/01/2022")
       },
       new Product()
        {
            Id = 2,
            Name = "120x90 Pine Post",
            Description = "Pine Posts - Construction",
            unitPrice = 2360,
            EffectiveFrom = DateTimeOffset.Parse("01/01/2022")
        }};
}

