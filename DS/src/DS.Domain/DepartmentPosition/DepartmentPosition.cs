namespace DS.Domain;

public class DepartmentPosition
{
    public Guid DepartmentId { get; private set; }
    public Guid PositionId { get; private set; }

    private DepartmentPosition() { }

    public DepartmentPosition(Guid departmentId, Guid positionId)
    {
        DepartmentId = departmentId;
        PositionId = positionId;
    }
}