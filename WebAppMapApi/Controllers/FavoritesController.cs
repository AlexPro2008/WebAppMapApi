using Microsoft.AspNetCore.Mvc;
using WebAppMapApi.Models;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoritesController(MapFactory factory) : ControllerBase
{
    [HttpPost("add-update-favorite")]
    public async Task<IActionResult> AddUpdateFavorite([FromBody] Favorite favorite)
    {
        Favorite? fav = factory.Favorites.First(e => e.Id == favorite.Id);

        string result;
        if (fav is null)
        {
            factory.Add(favorite);
            result = "Created";
        }
        else
        {
            factory.Update(favorite);
            result = "Updated";
        }

        await factory.SaveChangesAsync();

        return Ok(result);
    }

    [HttpDelete("remove-favorite")]
    public async Task<IActionResult> RemoveFavorite([FromBody] Favorite favorite)
    {
        Favorite? fav = factory.Favorites.First(e => e.Id == favorite.Id);

        string result = "Not found";
        if (fav is not null)
        {
            factory.Remove(favorite);
            result = "Removed";
            await factory.SaveChangesAsync();
        }

        return Ok(result);
    }
}
