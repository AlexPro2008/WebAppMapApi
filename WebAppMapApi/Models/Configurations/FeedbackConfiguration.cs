using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;
// для конфигурация Отзыва
public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
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
        builder.Property(f => f.Rating).IsRequired();

        // ограничение
        builder.ToTable(e => e
        .HasCheckConstraint("CK_Feedback_Rating", "Rating >= 1 AND Rating <= 5"));
    } // Configure

} // FeedbackConfiguration

