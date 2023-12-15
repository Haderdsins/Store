namespace Store.BLL.Models.Search;

public class CheapestStoreModel
{
    public int ProductId { get; set; }
    public int BatchCount { get; set; }
}
public class CheapestStoreBatchModel
{
    public List<CheapestStoreModel> BatchItems { get; set; }
}