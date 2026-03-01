using CSharpFunctionalExtensions;

namespace DS.Domain.Locations;

public class Location
{
    private readonly List<DepartmentLocation> _departments = [];
    
    public Guid Id { get; private set; }
    public LocationName Name { get; private set; }
    public Address Address { get; private set; }
    public Timezone Timezone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departments;

    private Location() { }

    private Location(LocationName name, Address address, Timezone timezone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Timezone = timezone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Location> Create(
        LocationName name,
        Address address,
        Timezone timezone)
    {
        return Result.Success(new Location(name, address, timezone));
    }
    
}