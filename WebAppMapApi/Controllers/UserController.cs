using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models.Entities;
using WebAppMapApi.Models;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(MapFactory factory) : ControllerBase
{
    [HttpPost("add-update-user")]
    public async Task<IActionResult> AddUpdateUser([FromBody] User user)
    {
        User? entry = factory.Users.First(e => e.Id == user.Id);

        string result;
        if (entry is null)
        {
            factory.Add(user);
            result = "Created";
        }
        else
        {
            factory.Update(user);
            result = "Updated";
        }

        await factory.SaveChangesAsync();

        return Ok(result);
    }
}
