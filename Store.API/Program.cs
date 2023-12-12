using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Store.BLL.Services.BatchOfProducts;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;
using Store.DAL.Database;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IBatchOfProductService, BatchOfProductService>();
builder.Services.AddScoped<IProductService, ProductService>();




builder.Services.AddControllers();
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