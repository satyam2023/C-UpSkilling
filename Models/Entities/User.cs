using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApis.Models.Entities;


using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public required string name { get; set; }
    public required string email{get;set;}
    public required int age{get;set;}

    [JsonIgnore]
     public required string passwordHash { get; set; }
}