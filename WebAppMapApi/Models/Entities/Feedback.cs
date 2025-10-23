using Microsoft.EntityFrameworkCore;
using WebAppMapApi.Models.Configurations;

namespace WebAppMapApi.Models.Entities;

// Отзыв на достопримечательность
[EntityTypeConfiguration(typeof(FeedbackConfiguration))]
public class Feedback
{
    public int Id { get; set; }

    // Текст отзыва
    public string Text { get; set; } = "";

    // Фотография (если есть)
    public string ImagePath { get; set; } = "";

    // Оценка
    public int Rating { get; set; }

    // Ответ владельца
    public string Response { get; set; } = string.Empty;

    // Аккаунт, который оставил отзыв
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
}
