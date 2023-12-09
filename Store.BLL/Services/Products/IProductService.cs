using Store.BLL.Models;

namespace Store.BLL.Services.Products;

public interface IProductService
{
    void CreateProduct(CreateProductModel model);
}