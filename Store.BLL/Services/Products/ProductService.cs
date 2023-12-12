using Store.BLL.Models;
using Store.BLL.Models.Create;
using Store.BLL.Models.Update;
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
    
    public void Delete(int ProductId)
    {
        var productToDelete = _dbContext.Products.Find(ProductId);

        if (productToDelete != null)
        {
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }
        else
        {
            // Обработка случая, когда магазин с указанным ID не найден
            throw new ArgumentException("Product not found.");
        }
    }
    public void Update(int productId, UpdateProductModel model)
    {
        var productToUpdate = _dbContext.Products.Find(productId);

        if (productToUpdate != null)
        {
            // Обновление атрибутов продукта
            productToUpdate.Name = model.Name; // Пример, добавьте другие атрибуты, которые необходимо обновить

            _dbContext.SaveChanges();
        }
        else
        {
            // Обработка случая, когда продукт с указанным ID не найден
            throw new ArgumentException("Product not found.");
        }
    }
}