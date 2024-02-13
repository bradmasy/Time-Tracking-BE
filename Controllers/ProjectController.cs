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


    [Authorize]
    [HttpGet]
    public IActionResult Get([FromQuery] ProjectQuery? query)
    {
        Console.WriteLine("/projects HIT");
        var userIdClaim = User.FindFirst("sub");
        var authorizationHeader = HttpContext.Request.Headers["Authorization"];
        var authorizationParts = authorizationHeader.ToString().Split(' ');
        string token = authorizationParts[1];
        string userId = _authService.GetUserFromJwt(token);

        if (!string.IsNullOrWhiteSpace(query.projectId))
        {
            var project = _context.Projects.Where(p => p.UserId.ToString() == userId && p.Id.ToString() == query.projectId);
            return Ok(project);
        }

        List<Project> projects = _context.Projects
            .Where(p => p.UserId.ToString() == userId)
            .ToList();

        return Ok(projects);
    }



}