using ContactWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactWebAPI.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
