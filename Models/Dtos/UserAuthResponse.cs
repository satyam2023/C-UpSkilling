namespace WebApis.Models.Dtos;

public record UserAuthResponse{
    public required string accessToken { get; set; }
    public  string? refreshToken { get; set; }
}