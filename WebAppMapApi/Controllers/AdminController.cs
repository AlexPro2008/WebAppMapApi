using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController(MapFactory factory) : ControllerBase
{
    [HttpGet("get-user-count")]
    public async Task<IActionResult> GetUserCount()
    {
        return Ok(await factory.Users.CountAsync());
    }
    [HttpGet("get-feedback-count")]
    public async Task<IActionResult> GetFeedbackCount()
    {
        return Ok(await factory.Feedbacks.CountAsync());
    }
    [HttpGet("get-feedback-response-count")]
    public async Task<IActionResult> GetFeedbackResponseCount()
    {
        return Ok(await factory.Feedbacks.CountAsync(x => x.Response.Length > 0));
    }
    [HttpGet("get-favorite-count")]
    public async Task<IActionResult> GetFavoriteCount()
    {
        return Ok(await factory.Favorites.CountAsync());
    }
    [HttpGet("get-location-count")]
    public async Task<IActionResult> GetLocationCount()
    {
        return Ok(await factory.Locations.CountAsync());
    }
}
