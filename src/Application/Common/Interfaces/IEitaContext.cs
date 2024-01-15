using EitaaGram.Client;

namespace NiceShop.Application.Common.Interfaces;

public interface IEitaContext
{
    public EitaaGramBotClient BotClient { get; set; }
    public string ChatId { get; set; }
}
