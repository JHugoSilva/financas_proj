using financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace financas.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
}