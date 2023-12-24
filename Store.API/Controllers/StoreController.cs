using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models.Create;
using Store.BLL.Models.Delete;
using Store.BLL.Models.Update;
using Store.BLL.Services.Stores;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;

    //принцип диайа
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }
    
    /// <summary>
    /// Создание магазина
    /// </summary>
    /// <param name="createStoreModel"></param>
    [HttpPost("CreateStore")]
    public void CreateStore(CreateStoreModel createStoreModel)
    {
        _storeService.Create(createStoreModel);
    }
    
    /// <summary>
    /// Удаление магазина
    /// </summary>
    /// <param name="deleteStoreModel"></param>
    [HttpDelete("DeleteStore")]
    public void DeleteStore(DeleteStoreModel deleteStoreModel)
    {
        _storeService.Delete(deleteStoreModel.StoreId);
    }
    
    
    /// <summary>
    /// Обновление магазина
    /// </summary>
    /// <param name="deleteProductModel"></param>
    [HttpPut("UpdateStore")]
    public void Update(UpdateStoreModel updateStoreModel)
    {
        _storeService.Update(updateStoreModel.StoreId, updateStoreModel);
    }
}