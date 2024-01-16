using EitaaGram.Bot.Methods;
using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Services;

public class EitaService(IEitaContext context) : IEitaService
{
    public async Task SendOtpAsync(int otp)
    {
        await context.BotClient.SendMessageAsync(context.ChatId, $"کد ورود شما : {otp} ");
    }
}
