using Microsoft.EntityFrameworkCore;
using MyApp.Models.Models;

namespace MyApp.DAL.Connection;

public class AppDbConnection(DbContextOptions<AppDbConnection> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Token> Tokens { get; set; }
    
}