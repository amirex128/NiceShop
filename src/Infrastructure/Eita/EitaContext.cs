using EitaaGram.Client;
using Microsoft.Extensions.Configuration;
using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Infrastructure.Eita;

public class EitaContext(IConfiguration configuration) : IEitaContext

{
    public EitaaGramBotClient BotClient { get; set; } = new EitaaGramBotClient(configuration["Eita:ApiKey"]);
    public string ChatId { get; set; } = configuration["Eita:ChatId"] ?? string.Empty;
}
