using A_DaTa.Context;
using A_DaTa.Models;
using B_Bus.Respositories;
using B_Bus.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDBContext>(c =>c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect")));
builder.Services.AddScoped<IBrandRes, BrandService>();
builder.Services.AddScoped<ICategoryRes, CategoryService>();
builder.Services.AddScoped<IOrderRes, OrderService>();
builder.Services.AddScoped<IProDuctRes, ProductService>();
builder.Services.AddScoped<IOrderDetailsRes, OrderDetailsService>();
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
