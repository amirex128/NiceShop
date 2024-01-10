using NiceShop.Application.Features.Medias.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Medias.Queries.GetById;

public record GetMediaByIdQuery(int Id) : IRequest<MediaDto?>;
