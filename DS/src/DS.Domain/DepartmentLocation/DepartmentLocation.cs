namespace DS.Domain;

public class DepartmentLocation
{

    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }
    


    private DepartmentLocation() { }
 
    public DepartmentLocation(Guid departmentId, Guid locationId)
    {
        DepartmentId = departmentId;
        LocationId = locationId;
    }
}