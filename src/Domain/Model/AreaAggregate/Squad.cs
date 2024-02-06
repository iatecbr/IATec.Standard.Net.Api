using Domain.SeedWorks;

namespace Domain.Model.AreaAggregate;

public class Squad : EntityInt32
{
    public string? Name { get; private set; }
    public int AmountPerson { get; private set; }

    private readonly List<Person> _persons;
    public IReadOnlyCollection<Person> Persons => _persons;

    protected Squad()
    {
        _persons = new List<Person>();
    }

    public Squad(string name, int amountPerson)
    {
        Name = name;
        AmountPerson = amountPerson;
        _persons = new List<Person>();
    }


    public void AddPerson(Person person)
    {
        _persons.Add(person);
        AmountPerson++;
    }
    
    public void RemovePerson(int personId)
    {
        var person = _persons.SingleOrDefault(s => s.Id == personId);
        if (person == null) 
            return;
        
        _persons.Remove(person);
        AmountPerson--;
    }
}