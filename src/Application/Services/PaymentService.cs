using System.Text.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;


namespace NiceShop.Application.Services;

public class PaymentService(IShepaRialContext shepaRialContext) : IPaymentService
{
    public async Task<ShepaPaymentResult?> RequestShepaPayment(long amount, string mobile, string email)
    {
        string result = await shepaRialContext.GetBankUrl(amount, mobile, email, "NiceShop Payment");

        ShepaPaymentResult? shepaPaymentResult = JsonSerializer.Deserialize<ShepaPaymentResult>(result);

        return shepaPaymentResult;
    }
}
