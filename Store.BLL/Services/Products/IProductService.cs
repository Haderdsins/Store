using Store.BLL.Models;
using Store.BLL.Models.Create;

namespace Store.BLL.Services.Products;

public interface IProductService
{
    void CreateProduct(CreateProductModel model);
    
    void Delete(int productId);
}