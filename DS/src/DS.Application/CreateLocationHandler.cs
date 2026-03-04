using DS.Application.Database;
using DS.Contracts;
using DS.Domain.Locations;

namespace DS.Application;

public class CreateLocationHandler
{
    private readonly ILocationRepository _locationRepository;


    public CreateLocationHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Guid> Handle(
        CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        var location = Location.Create(
            request.Name,
            request.Country,
            request.City,
            request.Street,
            request.StreetNumber,
            request.Room,
            request.PostalCode,
            request.Timezone);

        await _locationRepository.Add(location.Value, cancellationToken);

        return location.Value.Id;
    }
}