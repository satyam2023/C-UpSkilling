namespace WebApis.Models.Dtos;


public record UpdateUserRequest{
    public required int Id { get; set; }

    public string? email { get; set; }
    public int? age { get; set; }

}