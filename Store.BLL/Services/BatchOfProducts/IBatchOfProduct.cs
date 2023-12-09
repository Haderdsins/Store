using Store.BLL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public interface IBatchOfProduct
{
    void CreateBatchOfProduct(CreateBatchOfProductModel model);
}