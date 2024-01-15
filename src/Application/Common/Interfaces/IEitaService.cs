namespace NiceShop.Application.Common.Interfaces;

public interface IEitaService
{
    public Task SendOtpAsync(string otp);
}
