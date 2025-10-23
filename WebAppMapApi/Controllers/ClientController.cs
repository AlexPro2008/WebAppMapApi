using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models.Entities;
using WebAppMapApi.Models;
using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Records;

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
            return NotFound();

        return Ok(user);
    }

    [HttpGet("get-all")]
    public Task<IActionResult> GetAll()
    {
        // Метод синхронный, но должен возвращать Task
        // Заворачиваем результат в Task и возвращаем
        IActionResult status = Ok(factory.Users);
        return Task.FromResult(status);
    }

    [HttpPut("change-status")]
    public async Task<IActionResult> ChangeStatus([FromBody] UserStatusUpdate status)
    {
        User? user = await factory.Users.FirstAsync(e => e.Id == status.Id);

        if (user is null)
            return NotFound();

        user.Account.Status = status.Status;
        factory.Update(user);

        await factory.SaveChangesAsync();

        return Ok("Updated");
    }
}
