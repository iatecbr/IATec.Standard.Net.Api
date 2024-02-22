using Application.AreaFeatures.Queries.DTOs;
using MediatR;

namespace Application.AreaFeatures.Queries;

public sealed record GetAreaSquadQuery : IRequest<List<AreaSquadReadDto>>;