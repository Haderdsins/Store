using Store.BLL.Models;
using Store.DAL.Database;
using Store.DAL.Models;

namespace Store.BLL.Services.Products;

public class ProductService : IProductService
{
    private readonly StoreDbContext _dbContext;
    
    public ProductService(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void CreateProduct(CreateProductModel model)
    {
        var product = new Product();
        product.Name = model.Name;
        
        // logic to add database
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }
}