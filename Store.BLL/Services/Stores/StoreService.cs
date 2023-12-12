using Store.BLL.Models;
using Store.BLL.Models.Create;
using Store.DAL.Database;
using Store.DAL.Models;

namespace Store.BLL.Services.Stores;

public class StoreService : IStoreService
{
    private readonly StoreDbContext _dbContext;

    public StoreService(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(CreateStoreModel model)
    {
        var shop = new Shop();
        shop.Name = model.Name;
        shop.Address = model.Address;

        // logic to add database
        _dbContext.Stores.Add(shop);
        _dbContext.SaveChanges();
        
    }
    public void Delete(int StoreId)
    {
        var shopToDelete = _dbContext.Stores.Find(StoreId);

        if (shopToDelete != null)
        {
            _dbContext.Stores.Remove(shopToDelete);
            _dbContext.SaveChanges();
        }
        else
        {
            // Обработка случая, когда магазин с указанным ID не найден
            throw new ArgumentException("Store not found.");
        }
    }

    
}