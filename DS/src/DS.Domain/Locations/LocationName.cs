using CSharpFunctionalExtensions;

namespace DS.Domain.Locations;

public record LocationName
{
    private const int MaxLengthName = 150;
    private const int MinLengthName = 3;
    
    private LocationName()
    {
    }

    public string Name { get; private set; }

    private LocationName(string name)
    {
        Name = name;
    }

    public static Result<LocationName>  Create(string name)
    {
        if (name.Length > MaxLengthName || name.Length < MinLengthName)
        {
            return Result.Failure<LocationName>($"{name} is too long or short.");
        }
        return Result.Success<LocationName>(new LocationName(name));
    }
}