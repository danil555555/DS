using CSharpFunctionalExtensions;

namespace DS.Domain;

public record DepartmentName
{
    private const int MaxLength = 150;
    private const int MinLength = 3;
    public string Name { get; private set; }
    
    private DepartmentName(string name)
    {
        Name = name;
    }

    public static Result<DepartmentName> Create(string name)
    {
        if (name.Length > MaxLength ||  name.Length < MinLength)
            return Result.Failure<DepartmentName>("DepartmentName is required");
        
        if(string.IsNullOrWhiteSpace(name))
            return Result.Failure<DepartmentName>("Department name must be 3-150 characters");
        
        return Result.Success<DepartmentName>( new DepartmentName(name));
    }
}