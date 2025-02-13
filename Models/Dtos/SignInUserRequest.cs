namespace WebApis.Models.Dtos;


public record SignInUserRequest{
    public required string email{get;set;}
    public required string password{get;set;}
} 