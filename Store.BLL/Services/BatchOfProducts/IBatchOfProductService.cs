using Store.BLL.Models.Create;
using Store.BLL.Models.Get;
using Store.DAL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public interface IBatchOfProductService
{
    void CreateBatchOfProduct(CreateBatchOfProductModel model);
    
    void Delete(int itemId);
    Shop FoundStoreWhereMinPriceProduct(int productId);
    
    GetItemsForAmountModel GetItemsForAmount(decimal amount);
}   