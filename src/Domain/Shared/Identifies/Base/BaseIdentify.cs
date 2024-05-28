namespace Domain.Shared.Identifies.Base;

public abstract class BaseIdentify(string type)
{
    public string Value { get; private set; } = type;
}