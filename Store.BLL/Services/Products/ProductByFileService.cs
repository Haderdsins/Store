using System.Reflection.Metadata.Ecma335;
using Store.BLL.Commands;
using Store.BLL.Models.Create;
using Store.BLL.Models.Update;
using Store.DAL.Models;
using Store.DAL.Storages.FileStorage;

namespace Store.BLL.Services.Products;

public class ProductByFileService: IProductService
{
    private const string Name = "products.json";
    
    public async Task CreateAsync(ProductDtoCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
        };
            
        await FileManager.WriteToFileAsync(Name, product);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await FileManager.ReadAllFromFileAsync<Product>(Name);
        return(result);
    }
    
    
    
    public void CreateProduct(CreateProductModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(int productId)
    {
        throw new NotImplementedException();
    }

    public void Update(int productId, UpdateProductModel model)
    {
        throw new NotImplementedException();
    }
}