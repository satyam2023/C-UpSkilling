using System;
using Microsoft.EntityFrameworkCore;
using WebApis.Models.Entities;
namespace WebApis.Helpers;


public class DataContext : DbContext
{
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

    public DbSet<OrderTable> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }

}