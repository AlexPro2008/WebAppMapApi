using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;
[EntityTypeConfiguration(typeof(FeedbackResponseConfiguration))]
public class FeedbackResponse
{
    // ИД
    public int Id { get; set; }

    // Текст отзыва
    public string Text { get; set; } = "";

    // Аккаунт, который оставил отзыв
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;

} // Feedback