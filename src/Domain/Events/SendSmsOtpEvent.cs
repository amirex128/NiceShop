namespace NiceShop.Domain.Events;

public class SendSmsOtpEvent: BaseEvent
{
    public SendSmsOtpEvent(string phone, string otp)
    {
        Phone = phone;
        Otp = otp;
    }

    public string Phone { get; set; }
    public string Otp { get; set; }
}
