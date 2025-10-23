using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WebAppMapApi.Models.Entities.Favorite> builder)
    {
        // связываем данные
        // Аккаунт
        builder
            .HasOne(f => f.Account)
            .WithMany(a => a.Favorites)
            .HasForeignKey(f => f.AccountId);
    }
}
