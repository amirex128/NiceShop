using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Commands.Delete;

public record DeleteCouponCommand(int Id) : IRequest<Result>;
