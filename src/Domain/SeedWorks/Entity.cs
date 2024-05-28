using Domain.Contracts.Entities;
using Domain.Shared.Identifies.Base;

namespace Domain.SeedWorks;

public abstract class Entity<T> : IEntity
{
    public virtual T? Id { get; set; }

    public abstract bool IsUnassigned();

    public virtual BaseIdentify? GetSourceType()
    {
        return null;
    }

    public virtual object? GetLogContent()
    {
        return null;
    }

    public virtual string GetOwner()
    {
        return string.Empty;
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}