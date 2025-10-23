using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;
// избранные маршруты
[EntityTypeConfiguration(typeof(FavoriteConfiguration))]
public class Favorite
{
    // ИД
    public int Id { get; set; }

    // Точки координат
    public LineString? Coordinates { get; set; }

    // Описание
    public string Description { get; set; } = "";

    // Аккаунт, который добавил в избранное
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;

    public Favorite() { }
} // Favourite
