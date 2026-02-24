using CSharpFunctionalExtensions;

namespace DS.Domain.Locations;

public record Address
{
    private Address()
    {
    }
    private const int MaxLengthName = 150;
    private const int MinLengthName = 3;
    
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public int NumberStreet { get; private set; }
    public int Room {get; private set; }
    public int PostalCode { get; private set; }

    private Address(string country, string city, string street, int numberStreet, int room, int postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        NumberStreet = numberStreet;
        Room = room;
        PostalCode = postalCode;
    }

    public static Result<Address> Create(string country, string city, string street, int numberStreet, int room, int postalCode)
    {
        if (string.IsNullOrEmpty(country))
        {
            return Result.Failure<Address>("Country cannot be empty");
        }
        if (string.IsNullOrEmpty(city))
        {
            return Result.Failure<Address>("City cannot be empty");
        }
        if (string.IsNullOrEmpty(street))
        {
            return Result.Failure<Address>("Street cannot be empty");
        }

        if (numberStreet < 0)
        {
            return Result.Failure<Address>("NumberStreet cannot be negative");
        }

        if (room < 0)
        {
            return Result.Failure<Address>("Room cannot be negative");
        }

        if (postalCode < 0)
        {
            return Result.Failure<Address>("PostalCode cannot be negative");
        }
        return Result.Success<Address>(new Address(country, city, street, numberStreet, room, postalCode));
    }
}