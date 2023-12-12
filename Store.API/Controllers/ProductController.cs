using Microsoft.AspNetCore.Mvc;
using Store.BLL.Models.Create;
using Store.BLL.Models.Delete;
using Store.BLL.Models.Update;
using Store.BLL.Services.Products;

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
        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="deleteProductModel"></param>
        [HttpDelete("DeleteProduct")]
        public void Delete(DeleteProductModel deleteProductModel)
        {
            _productService.Delete(deleteProductModel.ProductId);
        }
        
        /// <summary>
        /// Обновление продукта
        /// </summary>
        /// <param name="updateProductModel"></param>
        [HttpPut("UpdateProduct")]
        public void Update(UpdateProductModel updateProductModel)
        {
            _productService.Update(updateProductModel.ProductId, updateProductModel);
        }
    }
}