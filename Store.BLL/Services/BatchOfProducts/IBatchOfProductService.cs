using Store.BLL.Models.Cart;
using Store.BLL.Models.Create;
using Store.BLL.Models.Get;
using Store.BLL.Models.Search;
using Store.BLL.Models.Update;
using Store.DAL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public interface IBatchOfProductService
{
    void CreateBatchOfProduct(CreateBatchOfProductModel model);
    
    void Delete(int itemId);
    Shop FoundStoreWhereMinPriceProduct(int productId);
    
    GetItemsForAmountModel GetItemsForAmount(decimal amount);
    
    void Update(int itemId, UpdateItemModel model);

    decimal PurchaseItems(Dictionary<int, int> itemQuantities);
    
    Shop FindCheapestStoreForBatches(List<CheapestStoreModel> batchItems);
}   