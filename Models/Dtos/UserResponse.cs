
namespace WebApis.Models.Dtos;
public class UserResponse
{
    public int Id{get;set;}
    public required string name { get; set; }
    public required string email { get; set; }
    public required string age { get; set; }
}
