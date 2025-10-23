using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;
using WebAppMapApi.Models.Entities.Enums;

namespace WebAppMapApi.Models.Entities;

// Аккаунт содержит информацию для авторизации
[EntityTypeConfiguration(typeof(AccountConfiguration))]
public class Account
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;

    // Путь
    public string Path { get; set; } = null!;

    // Связанный пользователь
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public Status Status { get; set; }

    public Role Role { get; set; }

    public virtual List<Feedback> Feedbacks { get; set; } = [];

    public virtual List<Favorite> Favorites { get; set; } = [];
}
