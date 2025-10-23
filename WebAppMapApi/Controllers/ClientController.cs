using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models.Entities;
using WebAppMapApi.Models;
using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Entities.Enums;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController(MapFactory factory) : ControllerBase
{
    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetById([FromBody] int id)
    {
        User? user = await factory.Users.FirstAsync(e => e.Id == id);

        if (user is null)
            return Ok("Not found");

        return Ok(user);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(factory.Users);
    }

    [HttpGet("change-status")]
    public async Task<IActionResult> ChangeStatus([FromBody] int id, [FromBody] Status status)
    {
        User? user = await factory.Users.FirstAsync(e => e.Id == id);

        if (user is null)
            return Ok("Not found");

        user.Account.Status = status;
        factory.Update(user);

        await factory.SaveChangesAsync();

        return Ok("Updated");
    }
}
