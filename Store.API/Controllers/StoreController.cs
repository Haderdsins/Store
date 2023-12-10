using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models;
using Store.BLL.Services.BatchOfProducts;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    private readonly IBatchOfProduct _batchOfProductService;

    private readonly IProductService _productService;
    //принцип диайа
    public StoreController(IStoreService storeService, IBatchOfProduct batchOfProductService, IProductService productService)
    {
        _storeService = storeService;
        _batchOfProductService = batchOfProductService;
        _productService = productService;
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
    /// Создание продукта
    /// </summary>
    /// <param name="createProductModel"></param>
    [HttpPost("CreateProduct")]
    public void CreateProduct(CreateProductModel createProductModel)
    {
        _productService.CreateProduct(createProductModel);
    }


    /// <summary>
    /// Создание позиции продукта в магазине
    /// </summary>
    /// <param name="createBatchOfProductModel"></param>
    [HttpPost("CreateBatchOfProduct")]
    public void CreateBatchOfProduct(CreateBatchOfProductModel createBatchOfProductModel)
    {
        _batchOfProductService.CreateBatchOfProduct(createBatchOfProductModel);
    }



}