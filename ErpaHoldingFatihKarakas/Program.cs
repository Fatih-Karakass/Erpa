using ErpaHoldingFatihKarakas.Application.Services.Baskets;
using ErpaHoldingFatihKarakas.Application.Services.Brands;
using ErpaHoldingFatihKarakas.Application.Services.Categories;
using ErpaHoldingFatihKarakas.Application.Services.Models;
using ErpaHoldingFatihKarakas.Application.Services.Orders;
using ErpaHoldingFatihKarakas.Application.Services.Products;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using ErpaHoldingFatihKarakas.Repository.Baskets;
using ErpaHoldingFatihKarakas.Repository.Brands;
using ErpaHoldingFatihKarakas.Repository.Categories;
using ErpaHoldingFatihKarakas.Repository.Models;
using ErpaHoldingFatihKarakas.Repository.Orders;
using ErpaHoldingFatihKarakas.Repository.Products;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IBasketServices, BasketService>();
builder.Services.AddScoped<IBrandServices, BrandServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IModelServices, ModelServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoriesRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
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
