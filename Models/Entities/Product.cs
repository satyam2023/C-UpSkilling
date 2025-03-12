
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public string CreatedBy { get; set; }

    public string ProductName { get; set; }

    public ProductDetail ProductDetail { get; set; }

}


public class ProductDetail
{
    [Key]
    public int ProductDetailId { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int MadeIn { get; set; }
    public int ProductPrice { get; set; }

    public int avlQty { get; set; }
}