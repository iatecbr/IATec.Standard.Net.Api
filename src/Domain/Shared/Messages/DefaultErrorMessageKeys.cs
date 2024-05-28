namespace Domain.Shared.Messages;

public static class DefaultErrorMessageKeys
{
    private const string InitialPath = "general.api.messages.";

    public const string CannotBeDeletedErrorMessageKey = $"{InitialPath}record-cannot-be-deleted";
    public const string ExpiredTokenMessageKey = $"{InitialPath}expired-token";
    public const string UserUnactivatedMessageKey = $"{InitialPath}user-is-unactivated";
    public const string EmptyFieldMessageKey = $"{InitialPath}empty-field";
    public const string AlreadyExistsMessageKey = $"{InitialPath}record-already-exists";
    public const string DifferentIdentifiersMessageKey = $"{InitialPath}different-identifiers";
    public const string CannotBeSmallerMessageKey = $"{InitialPath}record-cannot-be-smaller";
    public const string CannotBeBiggerMessageKey = $"{InitialPath}record-cannot-be-bigger";
    public const string ValueIsEmptyOrNullMessageKey = $"{InitialPath}value-is-empty-or-null";
    public const string InvalidMinValueMessageKey = $"{InitialPath}invalid-min-value";
    public const string InvalidRangeMessageKey = $"{InitialPath}invalid-range";
    public const string InvalidLengthMessageKey = $"{InitialPath}invalid-length";
    public const string InvalidFieldsMessageKey = $"{InitialPath}invalid-fields";
    public const string InvalidIdMessageKey = $"{InitialPath}invalid-id";
    public const string InvalidDateMessageKey = $"{InitialPath}invalid-date";
}