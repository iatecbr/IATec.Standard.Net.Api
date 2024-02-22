using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Application.AreaFeatures.Commands;

public class AddSquadToAreaCommandHandler(IAreaWriteRepository areaWriteRepository, IValidator<Squad> squadValidator) 
    : IRequestHandler<AddSquadToAreaCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddSquadToAreaCommand command, CancellationToken cancellationToken)
    {
        var area = await areaWriteRepository.GetByIdAsync(command.AreaId);
        if (area is null)
            return Response.NotFound<bool>();

        var squad = Squad.Create(command.Name, squadValidator);
        if (!squad.IsValid)
            return Response.Failed<bool>(squad.Messages);
        
        area.AddSquad(squad.Value);
        await areaWriteRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}