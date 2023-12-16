using System.ComponentModel.DataAnnotations;

namespace Store.BLL.Commands;

public class ProductDtoCommand
{
    [Required] public string Name { get; set; } = null!;
    
    [Required] public string Color { get; set; } = null!;

    public string? Description { get; set; }
}