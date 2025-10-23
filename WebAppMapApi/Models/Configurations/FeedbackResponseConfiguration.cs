using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;
// для конфигурация Отзыва
public class FeedbackResponseConfiguration : IEntityTypeConfiguration<Feedback>
{
    // конфигурируем
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        // Связываем сущности
        // Аккаунт
        builder
            .HasOne(f => f.Account)
            .WithMany(a => a.Feedbacks)
            .HasForeignKey(f => f.AccountId);
        // Обязательные поля
        builder.Property(f => f.Text).HasMaxLength(1000).IsRequired();
    } // Configure

} // FeedbackConfiguration
