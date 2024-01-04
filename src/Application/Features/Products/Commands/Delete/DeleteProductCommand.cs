using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Commands.Delete;

public record DeleteProductCommand(int Id) : IRequest<Result>;
