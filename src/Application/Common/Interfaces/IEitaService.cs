namespace NiceShop.Application.Common.Interfaces;

public interface IEitaService
{
    public Task SendOtpAsync(int otp);
}
