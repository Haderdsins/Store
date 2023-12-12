using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models.Create;
using Store.BLL.Models.Delete;
using Store.BLL.Models.Other;
using Store.BLL.Services.BatchOfProducts;
using Store.DAL.Models;

namespace Store.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ItemController : ControllerBase
  {
    private readonly IBatchOfProductService _batchOfProductServiceService;
    private readonly IBatchOfProductService _storeWhereMinPriceProductService;
    private readonly IBatchOfProductService _getItemsForAmountService;
    public ItemController(IBatchOfProductService batchOfProductServiceService, IBatchOfProductService storeWhereMinPriceProduct, IBatchOfProductService getItemsForAmount, IBatchOfProductService getItemsForAmountService)
    {
      _batchOfProductServiceService = batchOfProductServiceService;
      _storeWhereMinPriceProductService = storeWhereMinPriceProduct;
      _getItemsForAmountService = getItemsForAmountService;
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
      var result = _storeWhereMinPriceProductService.FoundStoreWhereMinPriceProduct(productId);
      // Возвращение результата клиенту, например, в форме JSON
      return Ok(result);
    }
    
    /// <summary>
    /// Удаление позиции продукта из магазина
    /// </summary>
    /// <param name="deleteProductModel"></param>
    [HttpDelete("DeleteItem")]
    public void Delete(DeleteBatchOfProductModel deleteBatchOfProductModel)
    {
      _batchOfProductServiceService.Delete(deleteBatchOfProductModel.ItemId);
    }
    /// <summary>
    /// Понять какие товары можно купить в магазине на некоторую сумму
    /// </summary>
    /// <param name="deleteBatchOfProductModel"></param>
    [HttpGet("FountItemsInPrice")]
    public ActionResult<IEnumerable<(OmgItem item, int quantity)>> GetItemsInPrice([FromQuery] int productId, [FromQuery] decimal amount)
    {
      var itemsForAmount = _getItemsForAmountService.GetItemsForAmount(productId, amount);
      return Ok(itemsForAmount);
    }
  }  
}

