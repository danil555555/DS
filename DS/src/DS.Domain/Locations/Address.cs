using CSharpFunctionalExtensions;
using DS.Domain.Shared;

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

    public static Result<Address, Error> Create(string country, string city, string street, int numberStreet, int room, int postalCode)
    {
        if (string.IsNullOrEmpty(country))
        {
            return Result.Failure<Address, Error>(
                Error.Validation(null, "Country cannot be empty", nameof(country)));
        }

        if (string.IsNullOrEmpty(city))
        {
            return Result.Failure<Address, Error>(
                Error.Validation(null, "City cannot be empty", nameof(city)));
        }

        if (string.IsNullOrEmpty(street))
        {
            return Result.Failure<Address, Error>(
                Error.Validation(null, "Street cannot be empty", nameof(street)));
        }

        if (numberStreet < 0)
        {
            return Result.Failure<Address, Error>(
                Error.Validation(null, "NumberStreet cannot be negative", nameof(numberStreet)));
        }

        if (room < 0)
        {
            return Result.Failure<Address, Error>(
                Error.Validation(null, "Room cannot be negative", nameof(room)));
        }

        if (postalCode < 0)
        {
            return Result.Failure<Address, Error>(
                Error.Validation(null, "PostalCode cannot be negative", nameof(postalCode)));
        }

        return Result.Success<Address, Error>(
            new Address(country, city, street, numberStreet, room, postalCode));
    }
}