using Kavenegar.Core.Models;
using NiceShop.Application.Common.Exceptions;
using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Services;

public class SmsService(ISmsContext smsContext) : ISmsService
{
    public Task SendOtpSmsAsync(string phoneNumber, string otp)
    {
        SendResult sendResult = smsContext.Send(phoneNumber, otp).Result;
        if (sendResult.Status != 200)
        {
            throw new FailedSendSmsException(sendResult.StatusText);
        }

        return Task.CompletedTask;
    }
}
