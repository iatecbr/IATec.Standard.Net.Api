using Domain.Models.People.PeopleAggregator.Entities;
using Domain.Models.People.PeopleAggregator.ValueObjects.Person;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persistence.Models;

public class PersonPersistence
{
    [BsonId] public ObjectId Id { get; private set; }
    public int PersonId { get; private set; }
    public string ExternalId { get; private set; }

    public FirstNameValue FirstName { get; private set; }
    public LastNameValue LastName { get; private set; }
    public MiddleNameValue MiddleName { get; private set; }

    /// <summary>
    /// DynamoDb context maps lists of complex types automatically.
    /// </summary>
    public List<Document> Documents { get; private set; }

    /// <summary>
    /// DynamoDb map simple types automatically.
    /// </summary>
    public int Age { get; private set; }

    public PersonPersistence(int personId, string externalId, FirstNameValue firstName, LastNameValue lastName,
        MiddleNameValue middleName, List<Document> documents, int age)
    {
        Id = ObjectId.GenerateNewId();
        PersonId = personId;
        ExternalId = externalId;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Documents = documents;
        Age = age;
    }
}