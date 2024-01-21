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

public class ProjectController : ControllerBase
{


    public readonly DB.TimeTrackerDatabaseContext _context;
    private readonly AUTH.AuthService _authService;
    public ProjectController(DB.TimeTrackerDatabaseContext context, AUTH.AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProject project)
    {
        Console.WriteLine("POST /Project");
        Console.WriteLine(project);

        Project newProject = new Project
        {
            Name = project.Name,
            UserId = project.UserId,
            Budget = project.Budget,
            StartDate = project.StartDate,
            FinishDate = project.FinishDate,
            ProjectHours = project.ProjectHours,
            Description = project.Description
        };


        var addedProject = _context.Projects.Add(newProject);
        await _context.SaveChangesAsync();

        return Created($"/project/{addedProject.Entity.Id}", addedProject.Entity);
    }

    // [HttpGet] 
    // public async Task<IActionResult> Get([FromQuery] ProjectQuery? query){
    //     List<Project> projects = null;
    //     if(!string.IsNullOrEmpty(query.UserId)){
    //         projects = _context.Projects.Where(p => p.UserId.ToString() == query.UserId).ToList();
    //         Console.WriteLine(projects);
    //     }

    //     return Ok(projects);
    // }
    [Authorize]

    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("/projects HIT");
        // Extract user information from the JWT token
        // var info = AuthService.GetUserFromJwt(HttpContext.Request.Headers[""]);
        var userIdClaim = User.FindFirst("sub");
        Console.WriteLine(userIdClaim);
        var authorizationHeader = HttpContext.Request.Headers["Authorization"];
        var authorizationParts = authorizationHeader.ToString().Split(' ');
        string token = authorizationParts[1];
        Console.WriteLine(token);
        string userId = _authService.GetUserFromJwt(token);
        Console.WriteLine(userId);
        // string userId = userIdClaim.Value;

        // Find projects for the authenticated user
        List<Project> projects = _context.Projects
            .Where(p => p.UserId.ToString() == userId)
            .ToList();

        Console.WriteLine(projects);

        return Ok(projects);
    }
}