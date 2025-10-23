using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models;

// контекст базы данных

public class MapFactory : DbContext
{
    #region Сущности
    public DbSet<User> Users => Set<User>();

    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Feedback> Feedbacks => Set<Feedback>();

    public DbSet<Favorite> Favorites => Set<Favorite>();

    public DbSet<Location> Locations => Set<Location>();
    #endregion

    public MapFactory(DbContextOptions<MapFactory> options) : base(options)
    {
        // Создаем БД
        Database.EnsureCreated();
    }

}
