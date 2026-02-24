using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DS.Domain;

public record DepartmentIdentifier
{
    private const int MaxLength = 150;
    private const int MinLength = 3;
    public const string pattern = "[a-zA-Z]";
    public string Identifier { get; }

    private DepartmentIdentifier(string identifier)
    {
        Identifier = identifier;
    }

    public static Result<DepartmentIdentifier> Create(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            return Result.Failure<DepartmentIdentifier>("Identifier required");

        if (identifier.Length < MinLength || identifier.Length > MaxLength)
            return Result.Failure<DepartmentIdentifier>("Identifier length invalid");

        if (!Regex.IsMatch(identifier, pattern))
            return Result.Failure<DepartmentIdentifier>("Identifier must contain only latin letters");

        return Result.Success<DepartmentIdentifier>(new DepartmentIdentifier(identifier));
    }
}