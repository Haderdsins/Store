using Store.DAL.Models;

namespace Store.BLL.Services.MinPriceProducts;

public interface IStoreWhereMinPriceProductService
{
    Shop FoundStoreWhereMinPriceProduct(int productId);
}