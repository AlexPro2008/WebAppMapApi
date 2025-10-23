using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;

[EntityTypeConfiguration(typeof(UserConfiguration))]
public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Patronymic { get; set; } = "";

    // Связанный аккаунт
    public virtual Account Account { get; set; } = null!;
}