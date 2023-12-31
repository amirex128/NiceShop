namespace NiceShop.Application.Common.Interfaces;

public interface ISmsService
{
    Task SendOtpSmsAsync(string phoneNumber, string otp);

}
