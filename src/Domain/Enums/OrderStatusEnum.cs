namespace NiceShop.Domain.Enums;

public enum OrderStatusEnum
{
    WaitForPay,
    WaitForTryPay,
    Paid,
    WaitForSender,
    WaitForDelivery,
    Delivered,
    ReturnedTimeout,
    WaitForAcceptReturned,
    RejectReturned,
    WaitForSenderReturned,
    DeliveredReturned,
    WaitForReturnedPayBack,
    ReturnedPaid,
}
