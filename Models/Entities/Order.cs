using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApis.Models.Entities;

public class OrderTable
{
    [Key]
    public int OrderId { get; set; }
    public string? CreatedBy { get; set; }
}



public class OrderDetail
{
    [Key, ForeignKey("OrderTable")]
    public int OrderId { get; set; }

    public string? ItemName { get; set; }

    public int ItemPrice { get; set; }

    public int qty { get; set; }

}
