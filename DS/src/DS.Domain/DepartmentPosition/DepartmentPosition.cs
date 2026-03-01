using DS.Domain.Positions;

namespace DS.Domain;

public class DepartmentPosition
{
    public Guid DepartmentId { get; private set; }
    public Guid PositionId { get; private set; }
    
    public Guid DerpartmentPositionId { get; private set; }
    private DepartmentPosition() { }

    public DepartmentPosition(Guid departmentId, Guid positionId)
    {
        DerpartmentPositionId = Guid.NewGuid();
        DepartmentId = departmentId;
        PositionId = positionId;
    }
}