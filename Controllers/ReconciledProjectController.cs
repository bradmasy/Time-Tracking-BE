using DB = app_api.Database;
using Microsoft.AspNetCore.Mvc;
using app_api.Models;
using Microsoft.AspNetCore.Authorization;
using AUTH = app_api.Services;
namespace app_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReconciledProjectController : ControllerBase
{
    public readonly DB.TimeTrackerDatabaseContext _context;
    private readonly AUTH.AuthService _authService;

    public ReconciledProjectController(DB.TimeTrackerDatabaseContext context, AUTH.AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [Authorize]
    [HttpPost]
    public  IActionResult Post([FromBody] ReconciledProjectDepartment reconciledProjectDepartment)
    {
        Console.WriteLine("/ReconciledProjectDepartment POST");

        var message = reconciledProjectDepartment.Message;

        if (message == null || string.IsNullOrEmpty(message)) return BadRequest(new { error = "A message must be part of reconciled projects" });

        var version = reconciledProjectDepartment.Version;
        Console.WriteLine(version);

        var newReconciledProjectDepartment = new ReconciledProjectDepartment
        {
            Message = message,
            Version = reconciledProjectDepartment.Version,
            ProjectDepartmentId = reconciledProjectDepartment.ProjectDepartmentId,
            Hours = reconciledProjectDepartment.Hours,
            Actuals = reconciledProjectDepartment.Actuals,
            Forecast = reconciledProjectDepartment.Forecast
        };

        var reconciledProject =  _context.ReconciledProjectDepartments.AddAsync(newReconciledProjectDepartment);
        _context.SaveChangesAsync();

        return Ok(reconciledProject);
    }
}