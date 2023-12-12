using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models;
using Store.BLL.Services.BatchOfProducts;
using Store.BLL.Services.MinPriceProducts;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    private readonly IBatchOfProductService _batchOfProductServiceService;

    private readonly IStoreWhereMinPriceProductService _storeWhereMinPriceProduct;
    //принцип диайа
    public StoreController(IStoreService storeService, IBatchOfProductService batchOfProductServiceService, IStoreWhereMinPriceProductService storeWhereMinPriceProduct)
    {
        _storeService = storeService;
        _batchOfProductServiceService = batchOfProductServiceService;
        _storeWhereMinPriceProduct = storeWhereMinPriceProduct;
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
    
}