
using Microsoft.EntityFrameworkCore;
using Semester_3_API_Personal.Converters;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<BlogService, BlogServiceImpl>();
builder.Services.AddScoped<CouponsService, CouponsServiceImpl>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<OrderService, OrderServiceImpl>();
builder.Services.AddScoped<OrderDetailService, OrderDetailServiceImpl>();
builder.Services.AddScoped<CartService, CartServiceImpl>();
builder.Services.AddScoped<AddressService, AddressServiceImpl>();
builder.Services.AddScoped<ManufacturerService, ManufacturerServiceImpl>();

var app = builder.Build();

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseStaticFiles();

app.MapControllers();

app.Run();
