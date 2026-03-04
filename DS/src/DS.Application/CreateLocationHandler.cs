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
        var locatiomName = LocationName.Create(request.Name);
        if (locatiomName.IsFailure)
        {
            throw new ArgumentException("Name is empty");
        }
        
        var address = Address.Create(
            request.Country,
            request.City,
            request.Street,
            request.StreetNumber,
            request.Room,
            request.PostalCode);

        if (address.IsFailure)
        {
            throw new ArgumentException("Address is empty");
        }
        
        var timezone = Timezone.Create(request.Timezone);

        if (timezone.IsFailure)
        {
            throw new ArgumentException("Timezone is empty");
        }
        
        var location = Location.Create(
            locatiomName.Value,
            address.Value,
            timezone.Value
            );

        if (location.IsFailure)
        {
            throw new ArgumentException("Location is empty");
        }

        await _locationRepository.Add(location.Value, cancellationToken);

        return location.Value.Id;
    }
}