using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController(MapFactory factory) : ControllerBase
{
    [HttpPost("add-update-location")]
    public async Task<IActionResult> AddUpdateLocation([FromBody] Location location)
    {
        Location? loc = factory.Locations.First(e => e.Id == location.Id);

        string result;
        if (loc is null)
        {
            factory.Add(location);
            result = "Created";
        }
        else
        {
            factory.Update(location);
            result = "Updated";
        }

        await factory.SaveChangesAsync();

        return Ok(result);
    }

    [HttpDelete("delete-location")]
    public async Task<IActionResult> DeleteLocation([FromBody] Location location)
    {
        Location? loc = factory.Locations.First(e => e.Id == location.Id);

        if (loc is not null)
        {
            factory.Remove(location);
            await factory.SaveChangesAsync();
        }
        else
        {
            return NotFound();
        }

        return Ok("Deleted");
    }
}
