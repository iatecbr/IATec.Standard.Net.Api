namespace Domain.Shared.Identifies.Logging;

public class LogActionType
{
    public string Value { get; private set; }

    private LogActionType(string type)
    {
        Value = type;
    }

    public static LogActionType Added => new("ADDED");
    public static LogActionType Modified => new("MODIFIED");
    public static LogActionType Deleted => new("DELETED");
}