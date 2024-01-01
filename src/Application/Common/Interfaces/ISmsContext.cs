using Kavenegar;
using Kavenegar.Core.Models;

namespace NiceShop.Application.Common.Interfaces;

public interface ISmsContext
{
    public KavenegarApi SmsClient { get; set; }
    public Task<SendResult> Send(string phoneNumber, string message);

}
