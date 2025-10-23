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

    public string ImagePath { get; set; } = "";
    // Оценка
    public int Rating { get; set; }

    public FeedbackResponse Response { get; set; } = null!;

    // Аккаунт, который оставил ответ на отзыв
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;

} // Feedback