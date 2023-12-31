using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Services;

public class SmsService : ISmsService
{
    public Task SendOtpSmsAsync(string phoneNumber, string otp)
    {
        throw new NotImplementedException();
    }
}
