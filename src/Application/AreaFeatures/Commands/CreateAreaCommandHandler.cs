using Domain.Contracts.Repositories;
using Domain.Model.AreaAggregate;
using Domain.Shared;
using FluentValidation;
using MediatR;

namespace Application.AreaFeatures.Commands;

public class CreateAreaCommandHandler(IAreaWriteRepository areaWriteRepository, IValidator<Area> areaValidator) 
    : IRequestHandler<CreateAreaCommand, Response<int?>>
{
    public async Task<Response<int?>> Handle(CreateAreaCommand command, CancellationToken cancellationToken)
    {   
        var area = Area.Create(command.Name, command.Manager, areaValidator);
        if (!area.IsValid)
            return Response.Failed<int?>(area.Messages);

        await areaWriteRepository.AddAsync(area.Value);
        await areaWriteRepository.SaveChangesAsync(cancellationToken);
    
        return area.Value.Id;
    }
}