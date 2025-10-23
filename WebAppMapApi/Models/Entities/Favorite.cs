using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;
// избранные маршруты
[EntityTypeConfiguration(typeof(FavoriteConfiguration))]
public class Favorite()
{
    public int Id { get; set; }

    // Точки маршрута
    public LineString? Coordinates { get; set; }

    public string Description { get; set; } = "";

    // Аккаунт, который добавил в избранное
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
}
