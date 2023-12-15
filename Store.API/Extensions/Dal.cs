using Microsoft.EntityFrameworkCore;
using Store.BLL.Services.BatchOfProducts;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;
using Store.DAL.Database;

namespace Store.API.Extensions;

public static class Dal
{
    public static void AddDAL(this WebApplicationBuilder builder)
    {
        var implementationType = bool.TryParse(builder.Configuration["IsFileStorage"], out var isFileStorage);

        if (implementationType && isFileStorage)
        {
            builder.Services.AddScoped<IStoreService, StoreByFileService>();
            builder.Services.AddScoped<IBatchOfProductService, BatchOfProductByFileService>();
            builder.Services.AddScoped<IProductService, ProductByFileService>();
        }
        else
        {
            builder.Services.AddScoped<IStoreService, StoreByBDService>();
            builder.Services.AddScoped<IBatchOfProductService, BatchOfProductByBDService>();
            builder.Services.AddScoped<IProductService, ProductByBDService>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Connection string is missing.");
            }

            builder.Services.AddDbContext<StoreDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}