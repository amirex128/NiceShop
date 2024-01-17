namespace NiceShop.Application.Common.Interfaces;

public interface IShepaRialContext
{
    public Task<string> Request(long amount, string mobile, string email, string description);
    public Task<string> Verify(string token, long amount);

}
