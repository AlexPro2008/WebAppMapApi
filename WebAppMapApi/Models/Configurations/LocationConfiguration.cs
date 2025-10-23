using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Models.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        // Добавляем тестовые данные
        builder.HasData(Enumerable.Range(1, 5).Select(s => new Location()
        {
            Id = s,
            Name = $"Место {s}"
        }));
    }
}
