using Store.BLL.Models;
using Store.BLL.Models.Create;
using Store.BLL.Models.Get;
using Store.BLL.Models.Update;
using Store.DAL.Database;
using Store.DAL.Models;

namespace Store.BLL.Services.Stores;

public class StoreByBDService : IStoreService
{
    private readonly StoreDbContext _dbContext;

    public StoreByBDService(StoreDbContext dbContext)
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
    
    
    
    public void Update(int storeId, UpdateStoreModel model)
    {
        var storeToUpdate = _dbContext.Stores.Find(storeId);

        if (storeToUpdate != null)
        {
            // Обновление атрибутов продукта
            storeToUpdate.Name = model.Name; // Пример, добавьте другие атрибуты, которые необходимо обновить
            storeToUpdate.Address = model.Address;

            _dbContext.SaveChanges();
        }
        else
        {
            // Обработка случая, когда продукт с указанным ID не найден
            throw new ArgumentException("Store not found.");
        }
    }

    
}