﻿using Store.BLL.Models;
using Store.DAL.Database;
using Store.DAL.Models;

namespace Store.BLL.Services.BatchOfProducts;

public class BatchOfProduct
{
    private readonly StoreDbContext _dbContext;
    
    public BatchOfProduct(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void CreateBatchOfProduct(CreateBatchOfProductModel model)
    {
        var omgitem = new OmgItem();
        omgitem.StoreId = model.StoreId;
        omgitem.ProductId = model.ProductId;
        omgitem.Count = model.Count;
        omgitem.Price = model.Price;
        
        // logic to add database
        _dbContext.Items.Add(omgitem);
    }
}