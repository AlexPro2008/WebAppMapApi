using WebAppMapApi.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace WebAppMapApi.Models.Entities;

[EntityTypeConfiguration(typeof(LocationConfiguration))]
public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public TimeOnly OpeningTime { get; set; } = TimeOnly.MinValue;
    public TimeOnly ClosingTime { get; set; } = TimeOnly.MaxValue;

    public List<string> CustomImagePaths { get; set; } = [];
    public List<Feedback> Feedbacks { get; set; } = [];

    public int OwnerId;
    public Account Owner = null!;
}
