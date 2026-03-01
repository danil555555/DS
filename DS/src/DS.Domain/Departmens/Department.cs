using CSharpFunctionalExtensions;

namespace DS.Domain;

public class Department
{
    private readonly List<DepartmentLocation> _locations = [];
    private readonly List<DepartmentPosition> _positions = [];

    public Guid Id { get; private set; }

    public DepartmentName Name { get; private set; }

    public DepartmentIdentifier Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public DepartmentPath Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentLocation> DepartmentLocation => _locations;

    public IReadOnlyList<DepartmentPosition> DepartmentPosition => _positions;
    

    private Department() { }

    private Department(
        DepartmentName name,
        DepartmentIdentifier identifier,
        Guid? parentId,
        DepartmentPath path,
        short depth)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Department> Create(
        DepartmentName name,
        DepartmentIdentifier identifier,
        Guid? parentId,
        DepartmentPath path,
        short depth)
    {
        if (depth < 0 || depth > 150)
            return Result.Failure<Department>("Depth cannot be negative or more 150 symbols");

        return Result.Success(new Department(name, identifier, parentId, path, depth));
    }

    public void AddLocation(Guid locationId)
    {
        _locations.Add(new DepartmentLocation(Id, locationId));
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddPosition(Guid positionId)
    {
        _positions.Add(new DepartmentPosition(Id, positionId));
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}