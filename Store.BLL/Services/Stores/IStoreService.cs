using Store.BLL.Models;
using Store.BLL.Models.Create;
using Store.BLL.Models.Update;

namespace Store.BLL.Services.Stores;

public interface IStoreService
{
    void Create(CreateStoreModel model);
    void Delete(int storeId);

    void Update(int storeId, UpdateStoreModel model);
}