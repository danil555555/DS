using CSharpFunctionalExtensions;
using DS.Application.Database;
using DS.Domain.Locations;
using Microsoft.Extensions.Logging;

namespace DS.Infrastructure.Postgres.Repositories;

public class EfCoreLocationRepository : ILocationRepository
{
    private readonly DirectoryServiseDbContext _dbContext;
    private readonly ILogger<EfCoreLocationRepository> _logger;

    public EfCoreLocationRepository(DirectoryServiseDbContext dbContext,  ILogger<EfCoreLocationRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Result<Guid>> Add(Location location, CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.Locations.AddAsync(location, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(location.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            return Result.Failure<Guid>(ex.Message);
        }

    }

}