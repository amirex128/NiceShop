namespace NiceShop.Domain.Events;

public class SendOtpEvent : BaseEvent
{
    public SendOtpEvent(string? phone, string? email, int otp)
    {
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        Email = email ?? "";
        Otp = otp;
    }

    public string Phone { get; set; }
    public string Email { get; set; }
    public int Otp { get; set; }
}
