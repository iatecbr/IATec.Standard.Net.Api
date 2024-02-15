namespace Domain.Shared;

public class Response<TValue> : Response
{
    private readonly TValue? _value;
    public TValue Value => IsValid
        ? _value!
        : throw new InvalidOperationException("Value can not be null.");
    
    protected internal Response(TValue? value, List<string> messages, ResponseType responseType) 
        : base(messages, responseType)
    {
        _value = messages.Count == 0 ? value : default;
    }
    
    //Used by ValidatorPipelineBehavior
    public static Response<TValue> Failed(List<string> messageError) 
        => new(default, messageError, ResponseType.Failure);

    public static implicit operator Response<TValue>(TValue? value)
    {
        return value is not null 
            ? new Response<TValue>(value, [], ResponseType.Success) 
            : Failed<TValue>(string.Empty);
    }
}