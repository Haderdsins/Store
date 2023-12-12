using Store.BLL.Models;
using Store.BLL.Models.Create;

namespace Store.BLL.Services.Stores;

public interface IStoreService
{
    void Create(CreateStoreModel model);
    void Delete(int storeId);
}