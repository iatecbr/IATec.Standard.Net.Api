using IATec.Shared.Domain.SeedWorks;

namespace Domain.SeedWorks;

public class EntityNullable : Entity<string?>
{
    public override string GetOwner()
    {
        return $"{Id}";
    }

    public override bool IsUnassigned()
    {
        return string.IsNullOrEmpty(Id);
    }
}