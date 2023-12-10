
using Store.DAL.Database;
using Store.DAL.Models;

namespace Store.BLL.Services.MinPriceProducts
{
    public class StoreWhereMinPriceProductService : IStoreWhereMinPriceProductService
    {
        private readonly StoreDbContext _dbContext;

        public StoreWhereMinPriceProductService(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Shop FoundStoreWhereMinPriceProduct(int productId)
        {
            var cheapestItem = _dbContext.Items
                .Where(item => item.ProductId == productId)
                .OrderBy(item => item.Price)
                .FirstOrDefault();

            if (cheapestItem != null)
            {
                var store = _dbContext.Stores.Find(cheapestItem.StoreId);
                return store;
            }

            // Handle the case where the product is not found or no store has the product
            throw new Exception("Product not found or no store has the product.");
        }
    }
}