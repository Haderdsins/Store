using Store.BLL.Models.Create;
using Store.BLL.Models.Get;
using Store.BLL.Models.Search;
using Store.BLL.Models.Update;
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
    public void Update(int itemId, UpdateItemModel model)
    {
        var itemToUpdate = _dbContext.Items.Find(itemId);

        if (itemToUpdate != null)
        {
            // Обновление атрибутов продукта
            itemToUpdate.ProductId = model.ProductId; 
            itemToUpdate.StoreId = model.StoreId;
            itemToUpdate.Count = model.Count;
            itemToUpdate.Price = model.Price;
            _dbContext.SaveChanges();
        }
        else
        {
            // Обработка случая, когда продукт с указанным ID не найден
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
    public GetItemsForAmountModel GetItemsForAmount(decimal amount)
    {
        // Получаем все товары, цена которых не превышает заданную сумму и принадлежат указанному продукту
        var affordableItems = _dbContext.Items
            .Where(item => item.Price <= amount)
            .OrderBy(item => item.Price)
            .ToList();

        var result = new List<AffordableItemModel>();

        // Рассчитываем, сколько товаров можно купить для заданной суммы
        foreach (var item in affordableItems)
        {
            // Проверка на ноль
            if (item.Price != 0)
            {
                int quantity = (int)Math.Floor(amount / item.Price); // Изменение принципа расчета
                result.Add(new AffordableItemModel { Item = item, Quantity = quantity });
            }
        }

        return new GetItemsForAmountModel(result);
    }
    
    public Shop FindCheapestStoreForBatches(List<CheapestStoreModel> batchItems)
    {
        var productIds = batchItems.Select(batchItem => batchItem.ProductId).ToList();

        var cheapestStore = _dbContext.Items
            .Where(item => productIds.Contains(item.ProductId))
            .ToList() // Заменим AsEnumerable() на ToList() для выполнения части запроса на стороне сервера
            .GroupBy(item => item.StoreId)
            .Select(group => new
            {
                StoreId = group.Key,
                TotalPrice = group.Sum(item => item.Price * item.Count * batchItems
                    .Where(batchItem => batchItem.ProductId == item.ProductId)
                    .Sum(batchItem => batchItem.BatchCount))
            }).MinBy(result => result.TotalPrice);

        if (cheapestStore != null)
        {
            return _dbContext.Stores.Find(cheapestStore.StoreId);
        }

        // Вывести отладочную информацию
        Console.WriteLine("Product IDs: " + string.Join(", ", productIds));
        Console.WriteLine("Cheapest store is null");

        throw new Exception("No store found for the specified product batches.");
    }



    
    public decimal PurchaseItems(Dictionary<int, int> itemQuantities)
    {
        decimal totalCost = 0;

        foreach (var itemQuantity in itemQuantities)
        {
            int itemId = itemQuantity.Key;
            int quantityToBuy = itemQuantity.Value;

            var item = _dbContext.Items.FirstOrDefault(i => i.Id == itemId && i.Count >= quantityToBuy);

            if (item != null)
            {
                item.Count -= quantityToBuy;
                totalCost += item.Price * quantityToBuy;
            }
            else
            {

                throw new InvalidOperationException($"На складах недостаточно товара с id: {itemId}");
            }
        }

        _dbContext.SaveChanges();

        return totalCost;
    }
    
}