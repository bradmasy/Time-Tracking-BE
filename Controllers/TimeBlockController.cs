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


public class TimeBlockController : ControllerBase
{
    public readonly DB.TimeTrackerDatabaseContext _context;
    private readonly AUTH.AuthService _authService;

    public TimeBlockController(DB.TimeTrackerDatabaseContext context, AUTH.AuthService authService)
    {

        _context = context;
        _authService = authService;
    }

    [Authorize]
    [HttpGet]

    public IActionResult Get([FromQuery] TimeBlockQuery timeBlockQuery)
    {
        Console.WriteLine("GET /TimeBlock");
        try
        {
            if (timeBlockQuery.StartTime == null)
            {
                return BadRequest("No Start or End Time Provided. Please Provide Range of Times For Blocks");
            }

            var timeBlocks = _context.TimeBlocks.Where(tb => tb.StartTime >= timeBlockQuery.StartTime).ToList();
            return Ok(timeBlocks);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [Authorize]
    [HttpPost]

    public async Task<IActionResult> Post([FromBody] TimeBlock timeBlock)
    {
        Console.WriteLine("POST /TimeBlock");

        if (timeBlock == null)
        {
            return BadRequest("TimeBlock is null.");
        }

        try
        {
            Console.WriteLine(timeBlock);
            var timeBlockDto = new TimeBlock
            {
                UserId = timeBlock.UserId,
                StartTime = timeBlock.StartTime,
                EndTime = timeBlock.EndTime,
                Task = timeBlock.Task ?? null,
                ProjectId = timeBlock.ProjectId ?? null,
                CreatedAt = DateTime.Now,
            };

            var addedTimeBlockDto = await _context.TimeBlocks.AddAsync(timeBlockDto);

            await _context.SaveChangesAsync();

            return Created($"/timeBlock/{addedTimeBlockDto.Entity.Id}", addedTimeBlockDto.Entity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}