using Kavenegar;
using Kavenegar.Core.Models;
using Microsoft.Extensions.Configuration;
using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Infrastructure.Sms;

public class SmsContext(IConfiguration configuration) : ISmsContext
{
    public KavenegarApi SmsClient { get; set; } = new(configuration["Sms:ApiKey"]);

    public Task<SendResult> Send(string phoneNumber, string message)
    {
        return SmsClient.Send(configuration["Sms:Receptor"], phoneNumber, message);
    }

}
