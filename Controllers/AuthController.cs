
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using app_api.Services;
using app_api.Models;
using app_api.Database;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase{

    private readonly AuthService _authService;
    private readonly TimeTrackerDatabaseContext _context;

    public AuthController(AuthService authService, TimeTrackerDatabaseContext context)
    {
        Console.WriteLine("here");
        _authService = authService;
        _context = context;
    }


    [HttpPost("/auth/login")]
    public async Task<IActionResult> Login([FromBody] UserLogin loginModel)
    {
        Console.WriteLine("/auth/login HIT");

        string? username = loginModel.Username;
        string? password = loginModel.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return BadRequest(new { Error = "Username and password cannot be empty or null." });
        }

        var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            return BadRequest(new { Error = "Invalid username or password." });
        }

        string jwtToken = _authService.GenerateJwtToken(user.Id.ToString());

        // You can return the token in the response or handle it as needed
        return Ok(new { Token = jwtToken });
    }
}