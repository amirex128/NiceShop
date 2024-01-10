using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Medias.Commands.Delete;

public record DeleteMediaCommand(int Id) : IRequest<Result>;
