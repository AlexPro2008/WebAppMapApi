using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;
// для конфигурация Избранного   
public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    // конфигурируем
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WebAppMapApi.Models.Entities.Favorite> builder)
    {
        // связываем данные
        // Аккаунт
        builder
            .HasOne(f => f.Account)
            .WithMany(a => a.Favorites)
            .HasForeignKey(f => f.AccountId);
  


    } // Configure
} // FavoriteConfiguration

