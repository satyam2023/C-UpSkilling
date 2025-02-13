using System;
using Microsoft.EntityFrameworkCore;
using WebApis.Models.Entities;
namespace WebApis.Helpers;


public class DataContext : DbContext{
 protected readonly IConfiguration Configuration;
  public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

       protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

     public DbSet<User> Users { get; set; }

}