using DB = app_api.Database;
using Microsoft.AspNetCore.Mvc;
using app_api.Models;
using Microsoft.AspNetCore.Authorization;
using AUTH = app_api.Services;
namespace app_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectDepartmentController : ControllerBase
{
    public readonly DB.TimeTrackerDatabaseContext _context;
    private readonly AUTH.AuthService _authService;


    public ProjectDepartmentController(DB.TimeTrackerDatabaseContext context, AUTH.AuthService authService)
    {
        _context = context;
        _authService = authService;
    }


    [Authorize]
    [HttpGet]

    public IActionResult Get([FromQuery] ProjectQuery? query)
    {
        
        if(!string.IsNullOrWhiteSpace(query.projectId))
        {
            var associatingProjectDepartments = _context.ProjectDepartments.Where(pd => pd.ProjectId.ToString() == query.projectId).ToList();
            return Ok(associatingProjectDepartments);
        }
        var projectDepartments = _context.ProjectDepartments.ToList();

        return Ok(projectDepartments);
    }
}