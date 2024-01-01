namespace NiceShop.Domain.Events;

public class SendOtpEvent : BaseEvent
{
    public SendOtpEvent(string phone, string email, string otp)
    {
        Phone = phone;
        Email = email;
        Otp = otp;
    }

    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required string Otp { get; set; }
}
