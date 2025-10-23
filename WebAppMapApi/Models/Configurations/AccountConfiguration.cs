using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;
// для конфигурация Аккаунта   
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    // конфигурируем
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WebAppMapApi.Models.Entities.Account> builder)
    {
        // связываем данные
        // Пользователь
        builder
            .HasOne(a => a.User)
            .WithOne(u => u.Account)
            .HasForeignKey<Account>(a => a.UserId);

        // Отзывы
        builder
            .HasMany(a => a.Feedbacks)
            .WithOne(f => f.Account)
            .HasForeignKey(f => f.AccountId);

        // Избранные
        builder
            .HasMany(a => a.Favorites)
            .WithOne(f => f.Account)
            .HasForeignKey(f => f.AccountId);

        // Обязательные поля
        builder.Property(a => a.Login).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Password).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Path).HasMaxLength(200).IsRequired();
        // добавляем данные
        builder.HasData(
            new WebAppMapApi.Models.Entities.Account
            {
                Id = 1,
                Login = "ivanov",
                Password = "password123",
                Path = "/users/ivanov",
                UserId = 1,
                Status = WebAppMapApi.Models.Entities.Enums.Status.Active,
                Role = WebAppMapApi.Models.Entities.Enums.Role.General
            }
        );
    } // Configure
} // AccountConfiguration
