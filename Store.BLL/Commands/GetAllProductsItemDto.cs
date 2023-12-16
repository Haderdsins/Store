namespace Store.BLL.Commands;

public class GetAllProductsItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Color { get; set; }

    public string? Description { get; set; }
}