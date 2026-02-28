using CSharpFunctionalExtensions;

namespace DS.Domain.Positions;

public class Position
{
    
    private readonly List<DepartmentPosition> _departments = [];
    public Guid Id { get; private set; }
    public PositionName Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public IReadOnlyList<DepartmentPosition> DepartmentPosition => _departments;
    private Position() { }

    private Position(PositionName name, string? description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Position> Create(PositionName name, string? description)
    {
        return Result.Success(new Position(name, description));
    }
    
}