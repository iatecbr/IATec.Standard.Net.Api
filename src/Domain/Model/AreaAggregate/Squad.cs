using Domain.SeedWorks;
using Domain.Shared;
using Domain.Shared.Extensions;
using FluentValidation;

namespace Domain.Model.AreaAggregate;

public class Squad : EntityInt32
{
    public int AreaId { get; private set; }
    public Area Area { get; private set; }
    public string? Name { get; private set; }
    public int AmountPerson { get; private set; }

    private readonly List<Person> _persons;
    public IReadOnlyCollection<Person> Persons => _persons;

    protected Squad()
    {
        _persons = new List<Person>();
    }

    private Squad(string name)
    {
        Name = name;
        AmountPerson = 0;
        _persons = new List<Person>();
    }
    
    public static Response<Squad> Create(string name, IValidator<Squad> validator)
    {
        var squad = new Squad(name);
        var validationResult = validator.Validate(squad);
        return Response.Create(squad, validationResult.MessageErrors());
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