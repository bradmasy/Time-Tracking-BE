using DB = app_api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models = app_api.Models;
using app_api.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using FirebaseAdmin.Auth;

namespace app_api.Controllers;


[ApiController]
[Route("[controller]")]

public class ProjectController: ControllerBase{


    public readonly DB.TimeTrackerDatabaseContext _context;
    public ProjectController(DB.TimeTrackerDatabaseContext context){
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProject project){
        Console.WriteLine("POST /Project");
        Console.WriteLine(project);

        Project newProject = new Project{
            Name = project.Name,
            UserId = project.UserId,
            Budget = project.Budget,
            StartDate = project.StartDate,
            FinishDate = project.FinishDate,
            ProjectHours = project.ProjectHours
        };


        var addedProject = _context.Projects.Add(newProject);
        await _context.SaveChangesAsync();

        return Created($"/project/{addedProject.Entity.Id}", addedProject.Entity);
    }

    [HttpGet] 
    public async Task<IActionResult> Get([FromQuery] ProjectQuery? query){
        List<Project> projects = null;
        if(!string.IsNullOrEmpty(query.UserId)){
            projects = _context.Projects.Where(p => p.UserId.ToString() == query.UserId).ToList();
            Console.WriteLine(projects);
        }
        
        return Ok(projects);
    }
}