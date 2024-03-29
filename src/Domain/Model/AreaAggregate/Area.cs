using Domain.SeedWorks;
using Domain.Shared;
using Domain.Shared.Extensions;
using FluentValidation;

namespace Domain.Model.AreaAggregate;

public class Area : EntityInt32
{
    public string? Name { get; private set; }
    public string? Manager { get; private set; }

    private readonly List<Squad> _squads;
    public IReadOnlyCollection<Squad> Squads => _squads;

    protected Area()
    {
        _squads = new List<Squad>();
    }

    private Area(string name, string manager)
    {
        Name = name;
        Manager = manager;
        _squads = new List<Squad>();
    }

    public static Response<Area> Create(string name, string manager, IValidator<Area> validator)
    {
        var area = new Area(name, manager);
        var validationResult = validator.Validate(area);
        return Response.Create(area, validationResult.MessageErrors());
    }

    public void AddSquad(Squad squad)
    {
        _squads.Add(squad);
    }

    public void Update(string name, string manager)
    {
        Name = name;
        Manager = manager;
    }

    public void RemoveSquad(int squadId)
    {
        var squad = _squads.SingleOrDefault(s => s.Id == squadId);
        if (squad != null) 
            _squads.Remove(squad);
    }
}