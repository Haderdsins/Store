﻿namespace Store.BLL.Models.Update;

public class UpdateStoreModel
{
    public int StoreId { get; set; }
    
    public string Name { get; set; }//Название создаваемого магазина
    
    public string Address { get; set; }//Адрес создаваемого магазина
}