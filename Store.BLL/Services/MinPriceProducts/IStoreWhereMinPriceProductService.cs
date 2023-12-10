using Store.BLL.Models;

namespace Store.BLL.Services.MinPriceProducts;

public interface IStoreWhereMinPriceProductService
{
    void FoundStoreWhereMinPriceProduct(MinPriceOfProductModel model);
}