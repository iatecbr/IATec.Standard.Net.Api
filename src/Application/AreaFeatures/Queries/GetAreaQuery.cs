using Application.AreaFeatures.Queries.DTOs;
using MediatR;

namespace Application.AreaFeatures.Queries;

public sealed record GetAreaQuery(int AreaId) : IRequest<AreaDto?>;