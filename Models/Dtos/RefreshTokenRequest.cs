namespace WebApis.Models.Dtos;

public record RefreshTokenRequest{
    public required string refreshToken{ get; set; }
}