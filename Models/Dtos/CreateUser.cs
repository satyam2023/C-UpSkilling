using System.ComponentModel.DataAnnotations;

namespace WebApis.Models.Dtos;


public record CreateUser{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(15),MinLength(4)]
    public required string name{get;set;} 


    [EmailAddress(ErrorMessage = "Email is not in correct format.")]
    [Required(ErrorMessage = "Email is required.")]
    public required string email{get;set;}


    [Required(ErrorMessage = "Age is required.")]
    [Range(10,150)]
    public required int age{get;set;}

    [Required(ErrorMessage="Role is mandatory")]
    public required string role{get;set;}

    [Required]
    [MinLength(6)]
    public required string password { get; set; }
    
   [Required]
[Compare("password")]    
    public required string confirmPassword {get;set;}
}