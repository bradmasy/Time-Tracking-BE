using Microsoft.AspNetCore.Mvc;
using Models = app_api.Models;
using DB = app_api.Database;
namespace app_api.Controllers;

using app_api.Models;
using Google.Api;
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
    public async Task<IActionResult> Get()
    {
        Console.WriteLine("/User HIT");
        var users = await _context.Users.ToListAsync();


        return Ok(users);
    }


    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] Models.UserLogin LoginModel)
    {
        Console.WriteLine("/login HIT");

        string? username = LoginModel.Username;
        string? password = LoginModel.Password;

        if (string.IsNullOrEmpty(username))
        {
            return BadRequest(new { Error = "Username cannot be empty or null." });
        }

        if (string.IsNullOrEmpty(password))
        {
            return BadRequest("Password cannot be empty or null.");
        }

        var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            return BadRequest(new { Error = "Invalid username or password." });
        }


        return Ok();
    }


    [HttpPost("/signup")]
    public async Task<IActionResult> SignUp([FromBody] Models.UserSignup SignupModel)
    {
        Console.WriteLine("/signup HIT");

        Models.User user = new Models.User
        {
            Username = SignupModel.Username,
            Password = SignupModel.Password,
            EmailAddress = SignupModel.Email,
            FirstName = SignupModel.FirstName,
            LastName = SignupModel.LastName
        };

        Type type = typeof(Models.User);

        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(user);

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return BadRequest(new { Error = "Invalid input: Property cannot be empty or null." });
            }
        }

        var exists =  await _context.Users.Where(u => u.Username == user.Username).FirstOrDefaultAsync();


        if (exists != null)
        {
            return BadRequest(new { Error = "User already exists." });
        }


        var addedUser = _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(addedUser.Entity);
    }
}
