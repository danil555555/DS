using DS.Application.Database;
using DS.Domain;
using DS.Domain.Locations;
using DS.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DS.Infrastructure.Postgres;

public class DirectoryServiseDbContext : DbContext
{
    private readonly string _connectionString;

    public DirectoryServiseDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiseDbContext).Assembly);
    }

    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Position> Positions => Set<Position>();

    public DbSet<DepartmentPosition> DepartmentPositions => Set<DepartmentPosition>();

    public DbSet<DepartmentLocation> DepartmentLocations => Set<DepartmentLocation>();
}