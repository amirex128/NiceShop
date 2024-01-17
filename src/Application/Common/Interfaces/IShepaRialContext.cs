namespace NiceShop.Application.Common.Interfaces;

public interface IShepaRialContext
{
    public Task<string> GetBankUrl(long amount, string mobile, string email, string description);

}
