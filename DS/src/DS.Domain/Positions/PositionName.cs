using CSharpFunctionalExtensions;

namespace DS.Domain.Positions;

public record PositionName
{
    private const int MaxLengthName = 150;
    private const int MinLengthName = 3;
    
    private PositionName()
    {
        
    }

    public string Name { get; private set; }

    private PositionName(string name)
    {
        Name = name;
    }

    public static Result<PositionName> Create(string name)
    {
        if (name.Length > MaxLengthName || name.Length < MinLengthName)
        {
            return Result.Failure<PositionName>($"{name} is too long or short.");
        }
        return Result.Success<PositionName>(new PositionName(name));
    }
}