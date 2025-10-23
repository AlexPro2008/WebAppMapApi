using WebAppMapApi.Models.Entities.Enums;

namespace WebAppMapApi.Records;

// Запись об изменении статуса пользователя
public record UserStatusUpdate(int Id, Status Status);