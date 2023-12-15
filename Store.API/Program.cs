using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Store.API.Extensions;
using Store.BLL.Services.BatchOfProducts;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;
using Store.DAL.Database;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStoreService, StoreByBDService>();
builder.Services.AddScoped<IBatchOfProductService, BatchOfProductByBDService>();
builder.Services.AddScoped<IProductService, ProductByBDService>();
builder.Services.AddControllers();


builder.AddDAL(); 


builder.Services.AddDbContext<StoreDbContext>(opt =>
{
    opt.UseNpgsql("Host=localhost;Port=5432;Database=store_db;Username=postgres;Password=postgres");
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v9999",
        Title = "Магазин 90-ые",
        Description = "Мы крышуем все магазины",
        Contact = new OpenApiContact
        {
            Name = "Васкин Максим Вадимович",
            Email = "maxifly0202@mail.ru",
            Url = new Uri("https://t.me/Haderdsins"),
        },
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();