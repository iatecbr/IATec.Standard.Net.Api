namespace Domain.Shared.Messages;

public static class StatusCodeMessageKeys
{
    private const string InitialPath = "general.api.messages.status-code.";

    public const string InternalServerErrorMessageKey = $"{InitialPath}internal-server-error";
    public const string ForbiddenMessageKey = $"{InitialPath}forbidden";
    public const string NotFoundMessageKey = $"{InitialPath}not-found";
    public const string NoContentMessageKey = $"{InitialPath}no-content";
    public const string CreatedMessageKey = $"{InitialPath}created";
    public const string ExternalServerErrorMessageKey = $"{InitialPath}external-server-error";
}