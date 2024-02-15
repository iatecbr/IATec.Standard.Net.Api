using Domain.Shared;
using MediatR;

namespace Application.AreaFeatures.Commands;

public sealed record CreateAreaCommand(string Name, string Manager) : IRequest<Response<int?>>;