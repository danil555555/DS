using DS.Domain.Locations;

namespace DS.Domain;

public class DepartmentLocation
{

    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }
    
    public Guid DepartmentLocationId { get; private set; }
    
    private DepartmentLocation() { }
 
    public DepartmentLocation(Guid departmentId, Guid locationId)
    {
        DepartmentLocationId = Guid.NewGuid();
        DepartmentId = departmentId;
        LocationId = locationId;
    }
}