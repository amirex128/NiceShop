using Microsoft.AspNetCore.Http;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Commands.Create;

public record CreateMediaCommand : IRequest<Result>
{
    public required IFormFile File { get; init; }
    public string? Alt { get; set; }
}
