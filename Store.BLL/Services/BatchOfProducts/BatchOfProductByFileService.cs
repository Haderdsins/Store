using Store.BLL.Models.Create;
using Store.BLL.Models.Get;
using Store.BLL.Models.Search;
using Store.BLL.Models.Update;
using Store.DAL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public class BatchOfProductByFileService: IBatchOfProductService
{
    public void CreateBatchOfProduct(CreateBatchOfProductModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int itemId)
    {
        throw new NotImplementedException();
    }

    public Shop FoundStoreWhereMinPriceProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public GetItemsForAmountModel GetItemsForAmount(decimal amount)
    {
        throw new NotImplementedException();
    }

    public void Update(int itemId, UpdateItemModel model)
    {
        throw new NotImplementedException();
    }

    public decimal PurchaseItems(Dictionary<int, int> itemQuantities)
    {
        throw new NotImplementedException();
    }

    public GetAllStoresModel FindCheapestStoreForBatches(List<CheapestStoreModel> batchItems)
    {
        throw new NotImplementedException();
    }
}