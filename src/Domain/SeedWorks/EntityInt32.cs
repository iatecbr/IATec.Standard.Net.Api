namespace Domain.SeedWorks;

public class EntityInt32 : Entity<int>
{
    public override string GetOwner()
    {
        return $"{Id}";
    }

    public override bool IsUnassigned()
    {
        return Id == 0;
    }
}