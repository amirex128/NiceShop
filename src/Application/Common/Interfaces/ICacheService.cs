namespace NiceShop.Application.Common.Interfaces;

public interface ICacheService
{
    public void Add(string key, object value);
    public void AddInterval(string key, object value, int timeSpan);
}
