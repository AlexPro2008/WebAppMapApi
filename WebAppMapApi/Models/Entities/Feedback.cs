using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;
// Отзыв аккаунта
[EntityTypeConfiguration(typeof(FeedbackConfiguration))]
public class Feedback
{
    // ИД
    public int Id { get; set; }

    // Текст отзыва
    public string Text { get; set; } = "";

    // Оценка
    public int Rating { get; set; }

    // Аккаунт, который оставил отзыв
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;

} // Feedback