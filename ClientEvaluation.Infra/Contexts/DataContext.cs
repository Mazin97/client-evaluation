using ClientEvaluation.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ClientEvaluation.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Evaluation> Evaluations { get; set; }

    public DbSet<Grade> Grades { get; set; }
}
