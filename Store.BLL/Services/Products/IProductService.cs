using Store.BLL.Models;
using Store.BLL.Models.Create;
using Store.BLL.Models.Update;

namespace Store.BLL.Services.Products;

public interface IProductService
{
    void CreateProduct(CreateProductModel model);
    
    void Delete(int productId);

    void Update(int productId, UpdateProductModel model);
}