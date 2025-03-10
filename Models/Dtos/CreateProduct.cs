using System.ComponentModel.DataAnnotations;

namespace WebApis.Models.Dtos;
public record CreateProduct
{
    [Required]
    public string ProductName { get; set; }
    public string CreatedBy { get; set; }
    [Required]
    public ProductDetailDTO ProductDetail { get; set; }
}

public record ProductDetailDTO
{
    public int MadeIn { get; set; }
    public int ProductPrice { get; set; }
    public int AvlQty { get; set; }
}
