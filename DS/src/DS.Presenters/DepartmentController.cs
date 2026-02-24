using DS.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DS.Presenters;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentDto departmentDto, CancellationToken cancellationToken)
    {
        return Ok("Department created");
    }
}
