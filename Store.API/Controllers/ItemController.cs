using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models;
using Store.BLL.Services.BatchOfProducts;
using Store.BLL.Services.MinPriceProducts;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;


namespace Store.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ItemController : ControllerBase
  {
    private readonly IBatchOfProductService _batchOfProductServiceService;
    private readonly IStoreWhereMinPriceProductService _storeWhereMinPriceProduct;
    
    public ItemController(IBatchOfProductService batchOfProductServiceService, IStoreWhereMinPriceProductService storeWhereMinPriceProduct)
    {
      _batchOfProductServiceService = batchOfProductServiceService;
      _storeWhereMinPriceProduct = storeWhereMinPriceProduct;
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
}

