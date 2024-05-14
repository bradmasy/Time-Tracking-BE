
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

public class CompanyController : ControllerBase
{

    public readonly DB.TimeTrackerDatabaseContext _context;
    private readonly AUTH.AuthService _authService;

    public CompanyController(DB.TimeTrackerDatabaseContext context, AUTH.AuthService authService)
    {

        _context = context;
        _authService = authService;
    }


    [Authorize]
    [HttpGet]

    public IActionResult Get([FromQuery] CompanyQuery companyQuery)
    {
        Console.WriteLine("/COMPANY Hit");

        Company company;
        try
        {
            if (string.IsNullOrWhiteSpace(companyQuery.CompanyId))
            {
                return BadRequest("No Company ID Provided. Please Provide Company ID");
            }

            company = _context.Companies.Where(c => c.Id.ToString() == companyQuery.CompanyId.ToString()).First();
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(company);
    }

}