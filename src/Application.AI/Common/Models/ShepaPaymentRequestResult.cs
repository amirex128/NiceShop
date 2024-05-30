namespace NiceShop.Application.AI.Common.Models;

public class ShepaPaymentRequestResult
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public object? Result { get; set; }
    public List<string>? Error { get; set; }
    public int ErrorCode { get; set; }
    public long Time { get; set; }
}
