namespace Domain.Shared.Identifies.Contexts;

public class ContextType
{
    public string Value { get; private set; }

    private ContextType(string type)
    {
        Value = type;
    }

    public static ContextType Domain => new("Domain");
    public static ContextType Application => new("Application");
}