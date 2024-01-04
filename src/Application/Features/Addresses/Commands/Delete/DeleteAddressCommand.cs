using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Delete;

public record DeleteAddressCommand(int Id) : IRequest<Result>;
