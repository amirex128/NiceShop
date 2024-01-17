using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Common.Interfaces;

public interface IPaymentService
{
    public Task<ShepaPaymentResult?> RequestShepaPayment(long amount, string mobile, string email);
}
