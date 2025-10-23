using WebAppMapApi.Models.Entities;

namespace WebAppMapApi.Records;

// Запись об изменении ответа владельца заведения на отзыв
public record FeedbackResponseUpdate(Feedback Feedback, string Response);