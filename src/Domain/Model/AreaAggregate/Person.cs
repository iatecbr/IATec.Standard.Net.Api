using Domain.SeedWorks;

namespace Domain.Model.AreaAggregate;

public class Person : EntityInt32
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public int Age { get; private set; }
    
    protected Person()
    {}

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public void Update(string? firstname, string? lastName, int age)
    {
        FirstName = firstname;
        LastName = lastName;
        Age = age;
    }
}