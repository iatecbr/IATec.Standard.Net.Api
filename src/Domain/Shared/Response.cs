namespace Domain.Shared;

public class Response
{
    private readonly List<string> _messages = [];
    public List<string> Messages => _messages;
    public bool IsValid => _messages.Count == 0;
    public ResponseType ResponseType { get; }
    
    protected internal Response(IEnumerable<string> messages, ResponseType responseType)
    {
        AddRangeMessages(messages);
        ResponseType = responseType;
    }

    private void AddRangeMessages(IEnumerable<string> messages)
    {
        _messages.AddRange(messages);
    }

    public void AddError(string message)
    {
        _messages.Add(message);
    }
    
    public static Response<TValue> NotFound<TValue>() => new(default, [], ResponseType.NotFound);
    public static Response<TValue> Failed<TValue>(List<string> messages) => new(default, messages, ResponseType.Failure);
    public static Response<TValue> Failed<TValue>(string message) => new(default, [message], ResponseType.Failure);

    public static Response<TValue> Create<TValue>(TValue value, List<string> messages)
    {
        var responseType = messages.Count > 0 ? ResponseType.Failure : ResponseType.Success;
        return new Response<TValue>(value, messages, responseType);
    }
}