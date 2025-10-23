using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
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

        builder.Property(f => f.Response).HasMaxLength(1000);

        // ограничение
        builder.ToTable(e => e
               .HasCheckConstraint("CK_Feedback_Rating", "Rating >= 1 AND Rating <= 5"));
    }
}
