namespace WebApis.Models.Dtos;

public class UserAuthResponse{
    public required string accessToken { get; set; }
    public  string? refreshToken { get; set; }
}