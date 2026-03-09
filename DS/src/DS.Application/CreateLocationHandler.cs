using CSharpFunctionalExtensions;
using DS.Application.Database;
using DS.Contracts;
using DS.Domain;
using DS.Domain.Locations;
using DS.Domain.Shared;

namespace DS.Application;

public class CreateLocationHandler
{
    private readonly ILocationRepository _locationRepository;


    public CreateLocationHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Result<Guid, Errors>> Handle(
        CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        var locationName = LocationName.Create(request.Name);
        if (locationName.IsFailure)
        {
            return Result.Failure<Guid, Errors>(
                new Errors(locationName.Error));
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
            return Result.Failure<Guid, Errors>(
                new Errors(address.Error));
        }
        
        var timezone = Timezone.Create(request.Timezone);

        if (timezone.IsFailure)
        {
            return Result.Failure<Guid, Errors>(
                new Errors(timezone.Error));
        }
        
        var location = Location.Create(
            locationName.Value,
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