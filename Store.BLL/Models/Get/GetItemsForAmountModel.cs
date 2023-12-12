using Store.DAL.Models;

namespace Store.BLL.Models.Get;

public class GetItemsForAmountModel
{
    public List<OmgItem> Items { get; set; }
    public int Quantity { get; set; }

    public GetItemsForAmountModel(List<OmgItem> items, int quantity)
    {
        Items = items;
        Quantity = quantity;
    }
}