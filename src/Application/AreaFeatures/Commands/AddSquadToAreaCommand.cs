using Domain.Shared;
using MediatR;

namespace Application.AreaFeatures.Commands;

public sealed record AddSquadToAreaCommand(int AreaId, string Name) : IRequest<Response<bool>>;