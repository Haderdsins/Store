using Store.BLL.Models.Create;
using Store.BLL.Models.Get;
using Store.DAL.Database;
using Store.DAL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public class BatchOfProductService : IBatchOfProductService
{
    private readonly StoreDbContext _dbContext;
    public BatchOfProductService(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void CreateBatchOfProduct(CreateBatchOfProductModel model)
    {
        var omgitem = new OmgItem();
        omgitem.StoreId = model.StoreId;
        omgitem.ProductId = model.ProductId;
        omgitem.Count = model.Count;
        omgitem.Price = model.Price;
        
        // logic to add database
        _dbContext.Items.Add(omgitem);
        _dbContext.SaveChanges();
        
    }
    
    public void Delete(int itemId)
    {
        var itemToDelete = _dbContext.Items.Find(itemId);

        if (itemToDelete != null)
        {
            _dbContext.Items.Remove(itemToDelete);
            _dbContext.SaveChanges();
        }
        else
        {
            // Обработка случая, когда магазин с указанным ID не найден
            throw new ArgumentException("Item not found.");
        }
    }
    
    public Shop FoundStoreWhereMinPriceProduct(int productId)
    {
        var cheapestItem = _dbContext.Items
            .Where(item => item.ProductId == productId)
            .OrderBy(item => item.Price)
            .FirstOrDefault();

        if (cheapestItem != null)
        {
            var store = _dbContext.Stores.Find(cheapestItem.StoreId);
            return store;
        }

        // Handle the case where the product is not found or no store has the product
        throw new Exception("Product not found or no store has the product.");
    }
//TODO: добавить в получаемые переменнные productId, имзенить принцип расчета quantity, проверку на ноли и округление
    public GetItemsForAmountModel GetItemsForAmount(int productId, decimal amount)
    {
        // Получаем все товары, цена которых не превышает заданную сумму и принадлежат указанному продукту
        var affordableItems = _dbContext.Items
            .Where(item => item.Price <= amount && item.ProductId == productId)
            .OrderBy(item => item.Price)
            .ToList();

        var result = new List<(OmgItem item, int quantity)>();

        // Рассчитываем, сколько товаров можно купить для заданной суммы
        foreach (var item in affordableItems)
        {
            // Проверка на ноль
            if (item.Price != 0)
            {
                int quantity = (int)Math.Floor(amount / item.Price); // Изменение принципа расчета
                result.Add((item, quantity));
            }
        }

        return new GetItemsForAmountModel(result.Select(item => item.item).ToList(), result.Sum(item => item.quantity));
    }

}