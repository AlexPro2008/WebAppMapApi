using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models;

// контекст базы данных

public class MapFactory : DbContext
{
    #region Сущности
    // коллекция Пользователей
    public DbSet<User> Users => Set<User>();

    // коллекция Аккаунтов
    public DbSet<Account> Accounts => Set<Account>();

    // коллекция Отзывов
    public DbSet<Feedback> Feedbacks => Set<Feedback>();

    // коллекция Избранных
    public DbSet<Favorite> Favorites => Set<Favorite>();

    // коллекция Локаций
    public DbSet<Location> Locations => Set<Location>();

    #endregion

    // конструктор
    public MapFactory(DbContextOptions<MapFactory> options) : base(options)
    {
        // создание бд
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    } // BirdFactory

} // BirdFactory
