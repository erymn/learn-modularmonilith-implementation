using System.Reflection;
using HazPro.HR.Model;
using Microsoft.EntityFrameworkCore;

namespace HazPro.HR.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
    
    public DbSet<Employee> Employees { get; set; }
}