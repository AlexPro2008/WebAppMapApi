using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackController(MapFactory factory) : ControllerBase
{
    [HttpPost("add-update-feedback")]
    public async Task<IActionResult> AddUpdateFavorite([FromBody] Feedback feedback)
    {
        Feedback? fb = factory.Feedbacks.First(e => e.Id == feedback.Id);

        string result;
        if (fb is null)
        {
            factory.Add(feedback);
            result = "Created";
        }
        else
        {
            factory.Update(feedback);
            result = "Updated";
        }

        await factory.SaveChangesAsync();

        return Ok(result);
    }

    [HttpDelete("delete-feedback")]
    public async Task<IActionResult> DeleteFeedback([FromBody] Feedback feedback)
    {
        Feedback? fav = factory.Feedbacks.First(e => e.Id == feedback.Id);

        string result = "Not found";
        if (fav is not null)
        {
            factory.Remove(feedback);
            result = "Removed";
            await factory.SaveChangesAsync();
        }

        return Ok(result);
    }
}
