using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MapController(MapFactory factory) : ControllerBase
{
    // тестовый метод
    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        var user = await factory.Users.Select(e => new {e.Id,FullName = $"{e.Surname} {e.Name} {e.Patronymic}"}).ToListAsync();
        return Ok(user);
    }
}
