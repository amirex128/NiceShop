using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Commands.Update;

public record UpdateMediaCommand : IRequest<Result>
{
    public int Id { get; init; }
    public string? Alt { get; set; }
}
