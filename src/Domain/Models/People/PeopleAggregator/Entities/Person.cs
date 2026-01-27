using Domain.Models.People.PeopleAggregator.ValueObjects.Person;
using IATec.Shared.Domain.SeedWorks;

namespace Domain.Models.People.PeopleAggregator.Entities;

public class Person : EntityUlidInt32
{
    public FirstNameValue FirstName { get; private set; }
    public MiddleNameValue? MiddleName { get; private set; }
    public LastNameValue LastName { get; private set; }

    private readonly List<Document> _documents;
    public IReadOnlyCollection<Document> Documents => _documents;

    private Person()
    {
        _documents = [];
    }
}