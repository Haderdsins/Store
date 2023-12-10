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
    private readonly IProductService _productService;

    private readonly IStoreWhereMinPriceProductService _storeWhereMinPriceProduct;
    //принцип диайа
    public StoreController(IStoreService storeService, IBatchOfProductService batchOfProductServiceService, IProductService productService, IStoreWhereMinPriceProductService storeWhereMinPriceProduct)
    {
        _storeService = storeService;
        _batchOfProductServiceService = batchOfProductServiceService;
        _productService = productService;
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
        _batchOfProductServiceService.CreateBatchOfProduct(createBatchOfProductModel);
    }

    /// <summary>
    /// Найти магазин с минимальным ценником на выбранный продукт
    /// </summary>
    /// <param name="minPriceOfProductModel"></param>
    /// <param name="productId">Идентификатор продукта</param>
    [HttpGet("FoundStoreWhereMinPriceProduct")]
    public IActionResult FoundStoreWhereMinPriceProduct(int productId)
    {
        var result = _storeWhereMinPriceProduct.FoundStoreWhereMinPriceProduct(productId);
    
        // Возвращение результата клиенту, например, в форме JSON
        return Ok(result);
    }






}