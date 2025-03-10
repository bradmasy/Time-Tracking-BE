
using DB = app_api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models = app_api.Models;
using app_api.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using AUTH = app_api.Services;
namespace app_api.Controllers;

[ApiController]
[Route("[controller]")]

public class DepartmentController : ControllerBase
{
    public readonly DB.TimeTrackerDatabaseContext _context;
    private readonly AUTH.AuthService _authService;
    public DepartmentController(DB.TimeTrackerDatabaseContext context, AUTH.AuthService authService)
    {

        _context = context;
        _authService = authService;
    }


    // [Authorize]
    [HttpGet]
    public IActionResult Get([FromQuery] DepartmentQuery? query)
    {
        Console.WriteLine("/department HIT");

        List<Department> departments;

        try
        {
            if (!string.IsNullOrWhiteSpace(query.CompanyId))
            {
                departments = _context.Departments.Where(dep => dep.CompanyId.ToString() == query.CompanyId).ToList();
            }

            if (!string.IsNullOrWhiteSpace(query.DepartmentId))
            {
                departments = _context.Departments.Where(dep => dep.Id.ToString() == query.DepartmentId).ToList();
                return Ok(departments);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        departments = _context.Departments.ToList();
        return Ok(departments);
    }
}
