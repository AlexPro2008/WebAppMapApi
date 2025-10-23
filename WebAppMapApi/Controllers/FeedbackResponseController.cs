using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackResponseController(MapFactory factory) : ControllerBase
{
    [HttpPost("add-update-response")]
    public async Task<IActionResult> AddUpdateResponse([FromBody] Feedback feedback, [FromBody] string response)
    {
        Feedback? fb = factory.Feedbacks.First(e => e.Id == feedback.Id);

        if (fb is null)
            return NotFound();

        fb.Response = response;
        factory.Update(feedback);

        await factory.SaveChangesAsync();

        return Ok("Updated");
    }

    [HttpDelete("delete-response")]
    public async Task<IActionResult> DeleteResponse([FromBody] Feedback feedback)
    {
        Feedback? fb = factory.Feedbacks.First(e => e.Id == feedback.Id);

        if (fb is not null)
        {
            fb.Response = "";
            factory.Update(fb);
            await factory.SaveChangesAsync();
        }
        else
        {
            return NotFound();
        }

        return Ok("Removed");
    }
}
