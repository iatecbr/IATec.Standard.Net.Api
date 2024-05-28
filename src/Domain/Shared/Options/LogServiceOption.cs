namespace Domain.Shared.Options;

public class LogServiceOption
{
    public const string Key = "IATec:Services:Log";
    public string Url { get; init; } = string.Empty;
}