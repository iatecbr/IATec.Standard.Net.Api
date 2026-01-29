namespace Domain.Models.People.PeopleAggregator.ValueObjects.Document;

public class IssuerValue(string value)
{
    private const int FieldMinLength = 1;
    public const int FieldMaxLength = 50;

    public string Value { get; } = value;
}