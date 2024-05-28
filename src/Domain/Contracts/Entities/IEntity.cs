using Domain.Shared.Identifies.Base;

namespace Domain.Contracts.Entities;

public interface IEntity
{
    public bool IsUnassigned();

    public BaseIdentify? GetSourceType();

    public string GetOwner();

    public object? GetLogContent();

    public string ToString();
}