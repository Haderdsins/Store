namespace Store.DAL.Models;

public class Shop
{
    public int Id { get; set; }//идентификатор магазина
    
    public string Name { get; set; }//название магазина
    
    public string Address { get; set; } //Адрес магазина

    public List<Product> Products { get; set; } = null!; //Список продуктов в магазине
    
}