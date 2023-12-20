using Microsoft.AspNetCore.Mvc;
using Models = app_api.Models;
using DB = app_api.Database;
namespace app_api.Controllers;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    // private readonly ILogger<UserController> _logger;
    public readonly DB.TimeTrackerDatabaseContext _context;
    public UserController(DB.TimeTrackerDatabaseContext context)
    {
        _context = context;
        
    }

    [HttpGet]
    public async Task<IActionResult> Get(){
        Console.WriteLine("/User HIT");
        var users = await _context.Users.ToListAsync();


        return Ok(users);
    }
}
