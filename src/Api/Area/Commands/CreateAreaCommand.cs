using MediatR;

namespace Api.Area.Commands;

public sealed record CreateAreaCommand(string Name, string Manager) : IRequest<int>
{
}