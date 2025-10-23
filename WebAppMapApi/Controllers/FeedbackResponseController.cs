using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackResponseController(MapFactory factory) : ControllerBase
{
    [HttpPost("add-update-response")]
    public async Task<IActionResult> AddUpdateResponse([FromBody] Feedback feedback, [FromBody] FeedbackResponse response)
    {
        Feedback? fb = factory.Feedbacks.First(e => e.Id == feedback.Id);

        if (fb is null)
            return Ok("Not found");

        fb.Response = response;

        string result;
        if (fb.Response is null)
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

    [HttpDelete("delete-response")]
    public async Task<IActionResult> DeleteResponse([FromBody] Feedback feedback)
    {
        Feedback? fb = factory.Feedbacks.First(e => e.Id == feedback.Id);

        string result = "Not found";
        if (fb is not null)
        {
            fb.Response = null!;
            factory.Update(fb);
            result = "Removed";
            await factory.SaveChangesAsync();
        }

        return Ok(result);
    }
}
