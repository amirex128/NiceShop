using System.Text.Json;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;


namespace NiceShop.Application.Services;

public class PaymentService(IShepaRialContext shepaRialContext) : IPaymentService
{
    public async Task<ShepaPaymentRequestResult?> RequestShepaPayment(long amount, string mobile, string email)
    {
        string result = await shepaRialContext.Request(amount, mobile, email, "NiceShop Payment");

        ShepaPaymentRequestResult? shepaPaymentResult = JsonSerializer.Deserialize<ShepaPaymentRequestResult>(result);

        return shepaPaymentResult;
    }
    
    public async Task<ShepaPaymentVerifyResult?> VerifyShepaPayment(string token, long amount)
    {
        string result = await shepaRialContext.Verify(token, amount);

        ShepaPaymentVerifyResult? shepaPaymentResult = JsonSerializer.Deserialize<ShepaPaymentVerifyResult>(result);

        return shepaPaymentResult;
    }
}
