using Microsoft.AspNetCore.Http;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Commands.Create;

public record CreateMediaCommand : IRequest<Result>
{
    public IFormFile File { get; init; } = null!;
    public string? Alt { get; set; }
}
