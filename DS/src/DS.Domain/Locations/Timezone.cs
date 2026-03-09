using CSharpFunctionalExtensions;
using DS.Domain.Shared;

namespace DS.Domain.Locations;

public record Timezone
{
    private const int MaxLengthName = 150;
    private const int MinLengthName = 3;
    
    private Timezone()
    {
    }

    public string IanaCode { get; private set; }

    private Timezone(string ianaCode)
    {
        IanaCode = ianaCode;
    }
    
    public static Result<Timezone, Error> Create(string ianaCode)
    {
        if (ianaCode.Length > MaxLengthName || ianaCode.Length < MinLengthName)
        {
            return Result.Failure<Timezone, Error>(
                Error.Validation(
                    code: "timezone.invalid",
                    message: $"{ianaCode} is too long or short.",
                    invalidField: nameof(ianaCode)));
        }

        return Result.Success<Timezone, Error>(
            new Timezone(ianaCode));
    }
}