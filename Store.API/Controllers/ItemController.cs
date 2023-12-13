using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models.Cart;
using Store.BLL.Models.Create;
using Store.BLL.Models.Delete;
using Store.BLL.Models.Other;
using Store.BLL.Models.Update;
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
    public ActionResult<IEnumerable<AffordableItemModel>> GetItemsInPrice(decimal amount)
    {
      var itemsForAmount = _getItemsForAmountService.GetItemsForAmount(amount);
      return Ok(itemsForAmount);
    }
    
    /// <summary>
    /// Обновление продукта в магазине
    /// </summary>
    /// <param name="updateProductModel"></param>
    [HttpPut("UpdateProduct")]
    public void Update(UpdateItemModel updateProductModel)
    {
      _batchOfProductServiceService.Update(updateProductModel.StoreId, updateProductModel);
    }
    
    /// <summary>
    /// Купить партию товаров в магазине
    /// </summary>
    /// <param name="cartItems"></param>
    /// <returns></returns>
    [HttpPost("PurchaseItems")]
    public IActionResult PurchaseItems([FromBody] List<CartItemModel> cartItems)
    {
      try
      {
        Dictionary<int, int> itemQuantities = cartItems.ToDictionary(item => item.ProductId, item => item.Count);
        decimal totalCost = _batchOfProductServiceService.PurchaseItems(itemQuantities);
        return Ok($"Purchase successful. Total cost: {totalCost}");
      }
      catch (Exception ex)
      {
        return BadRequest($"Purchase failed. Reason: {ex.Message}");
      }
    }
  }  
}

