using Store.BLL.Models;

namespace Store.BLL.Services.Stores;

public interface IStoreService
{
    void Create(CreateStoreModel model);
}