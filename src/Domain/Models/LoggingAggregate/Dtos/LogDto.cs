namespace Domain.Models.LoggingAggregate.Dtos;

public sealed record LogDto(
    string ContainerName,
    string Source,
    string Owner,
    string Action,
    string UserId,
    object? Content = null
);