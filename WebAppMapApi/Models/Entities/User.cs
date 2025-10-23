using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;

// Пользователь
// содержит базовую информацию о пользователе
[EntityTypeConfiguration(typeof(UserConfiguration))]
public class User
{
    // Ид
    public int Id { get; set; }

    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Patronymic { get; set; } = "";

    // Ид аккаунта
    public virtual Account Account { get; set; } = null!;

} // User