using Store.BLL.Models;
using Store.DAL.Database;


namespace Store.BLL.Services.MinPriceProducts;

public class StoreWhereMinPriceProductService
{
    private readonly StoreDbContext _dbContext;
    
    public StoreWhereMinPriceProductService(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void MinPriceOfProduct(MinPriceOfProductModel model)
    {
        // var result = new Store;
        //result.ProductId = model.ProductId;
        
        
        
    }
}