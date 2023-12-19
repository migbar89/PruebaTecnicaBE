using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnica.net7.Data.Repositories;

namespace PruebaTecnica.net7.Data;

public class UserContext : DbContext
{
    public DbSet<User> People { get; set; }
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public UserContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("default");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);

    }
}