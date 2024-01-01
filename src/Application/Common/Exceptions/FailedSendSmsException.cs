namespace NiceShop.Application.Common.Exceptions;

public class FailedSendSmsException(string message) : Exception(message);
