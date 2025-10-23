using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    // конфигурируем
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Связываем сущности
        // Аккаунт
        builder
            .HasOne(u => u.Account)
            .WithOne(a => a.User)
            .HasForeignKey<Account>(a => a.UserId);

        // Обязательные поля
        builder.Property(u => u.Surname).HasMaxLength(70).IsRequired();
        builder.Property(u => u.Name).HasMaxLength(70).IsRequired();
        builder.Property(u => u.Patronymic).HasMaxLength(70).IsRequired();

        // Добавляем тестовые данные
        builder.HasData(
            new User
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            }
        );
    }
}
