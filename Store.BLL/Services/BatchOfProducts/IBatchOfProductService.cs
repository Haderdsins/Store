using Store.BLL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public interface IBatchOfProductService
{
    void CreateBatchOfProduct(CreateBatchOfProductModel model);
}   