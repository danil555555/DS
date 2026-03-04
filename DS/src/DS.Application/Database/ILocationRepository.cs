using CSharpFunctionalExtensions;
using DS.Domain.Locations;

namespace DS.Application.Database;

public interface ILocationRepository
{
    Task<Result<Guid>> Add(Location location,  CancellationToken cancellationToken = default);
}