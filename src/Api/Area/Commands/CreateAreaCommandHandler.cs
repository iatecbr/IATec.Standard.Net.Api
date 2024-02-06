using Domain.Contracts.Repositories;
using Domain.SeedWorks;
using MediatR;

namespace Api.Area.Commands;

public class CreateAreaCommandHandler(IAreaRepository areaRepository, IUnitOfWork uow) : IRequestHandler<CreateAreaCommand, int>
{
    public async Task<int> Handle(CreateAreaCommand command, CancellationToken cancellationToken)
    {
        var area = new Domain.Model.AreaAggregate.Area(command.Name, command.Manager);
        
        await areaRepository.SaveAreaAsync(area);
        await uow.SaveChangesAsync(cancellationToken);

        return area.Id;
    }
}