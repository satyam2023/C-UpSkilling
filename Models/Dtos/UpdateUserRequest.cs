namespace WebApis.Models.Dtos;


public class UpdateUserRequest{
    public required int Id { get; set; }

    public string? email { get; set; }
    public int? age { get; set; }

}