using DS.Domain.Locations;

namespace DS.Domain;

public class DepartmentLocation
{

    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }
    
    public Department Department { get; private set; }
    public Location Location { get; private set; }


    private DepartmentLocation() { }
 
    public DepartmentLocation(Guid departmentId, Guid locationId)
    {
        DepartmentId = departmentId;
        LocationId = locationId;
    }
}