namespace NiceShop.Application.AI.Common.Models;

public class ShepaPaymentVerifyResult
{
    public bool Success { get; set; }
    public object? Result { get; set; }
    public List<string>? Errors { get; set; }
}
