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

            var timeBlocks = _context.TimeBlocks.Where(tb => tb.StartTime >= timeBlockQuery.StartTime && tb.EndTime <= timeBlockQuery.EndTime).ToList();

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

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] TimeBlock timeBlock)
    {
        Console.WriteLine("PATCH /TimeBlock");
        Console.WriteLine(id);
        Console.WriteLine(timeBlock);

        try
        {

            var queriedBlock = _context.TimeBlocks.FirstOrDefault(tb => tb.Id == id);

            if (queriedBlock != null)
            {
                queriedBlock.UpdatedAt = DateTime.Now;
                queriedBlock.EndTime = timeBlock.EndTime;
                queriedBlock.StartTime = timeBlock.StartTime;
                queriedBlock.ProjectId = timeBlock.ProjectId;
                queriedBlock.Task = timeBlock.Task;

                await _context.SaveChangesAsync();
                return Ok(queriedBlock);
            }

            return BadRequest("No Block with ID Found");
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [Authorize]
    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(Guid id)
    {

        try
        {
            var result = _context.TimeBlocks.FirstOrDefault(tb => tb.Id == id);

            if (result != null)
            {
                _context.TimeBlocks.Remove(result);

                await _context.SaveChangesAsync();
                return Ok("Successfully Deleted");
            }

            return BadRequest("Time Block not Found with ID");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }
    }

}