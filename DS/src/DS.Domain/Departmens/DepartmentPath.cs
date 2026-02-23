using CSharpFunctionalExtensions;

namespace DS.Domain;

public record DepartmentPath
{
    public string Value { get; }

    private DepartmentPath(string value)
    {
        Value = value;
    }

    public static Result<DepartmentPath> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<DepartmentPath>("Path required");

        return Result.Success<DepartmentPath>(new DepartmentPath(value));
    }
}