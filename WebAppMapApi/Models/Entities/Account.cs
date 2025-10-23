using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;
using WebAppMapApi.Models.Entities.Enums;

namespace WebAppMapApi.Models.Entities;
// Аккаунт содержит информацию для авторизации
[EntityTypeConfiguration(typeof(AccountConfiguration))]
public class Account
{
    // Ид
    public int Id { get; set; }
    // Логин
    public string Login { get; set; } = null!;
    // Пароль
    public string Password { get; set; } = null!;

    // Путь
    public string Path { get; set; } = null!;

    // Конкретный пользователь
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    // Статус
    public Status Status { get; set; }

    // Роль
    public Role Role { get; set; }

    // много отзывов
    public virtual List<Feedback> Feedbacks { get; set; } = [];

    // много избранных
    public virtual List<Favorite> Favorites { get; set; } = [];
} // Account

