using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthDemo.Infrastructure.Context;
public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> optionsBuilder)
        : base(optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly() );
    }
}
