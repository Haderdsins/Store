
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}