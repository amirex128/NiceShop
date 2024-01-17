using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Common.Interfaces;

public interface IPaymentService
{
    public Task<ShepaPaymentRequestResult?> RequestShepaPayment(long amount, string mobile, string email);
    public Task<ShepaPaymentVerifyResult?> VerifyShepaPayment(string token, long amount);

}
