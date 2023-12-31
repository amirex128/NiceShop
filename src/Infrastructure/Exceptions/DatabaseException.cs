using System;

namespace NiceShop.Infrastructure.Exceptions;

public class DatabaseException : Exception
{
    public string CustomMessage { get; }

    public DatabaseException(string message) : base(message)
    {
        CustomMessage = message;
    }

    public DatabaseException(string message, Exception innerException) : base(message, innerException)
    {
        CustomMessage = message;
    }

    public override string ToString()
    {
        string message = $"DatabaseException: {CustomMessage}";

        if (InnerException != null)
        {
            message = $"{message} --> {InnerException}";
        }

        return message;
    }
}
