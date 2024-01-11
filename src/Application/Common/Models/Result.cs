namespace NiceShop.Application.Common.Models;

public class Result
{
    public Result(bool succeeded, IEnumerable<string> errors, IEnumerable<string> success)
    {
        Succeeded = succeeded;
        ErrorMessages = errors.ToArray();
        SuccessMessages = success.ToArray();
    }

    public bool Succeeded { get; init; }
    public string[] SuccessMessages { get; init; }
    public string[] ErrorMessages { get; init; }

    public object? ResultObject { get; set; }

    public Result WithObject(object? resultObject)
    {
        ResultObject = resultObject;
        return this;
    }

    public static Result Created(params string[] success)
    {
        success = success.Append("مورد با موفقیت ایجاد شد.").ToArray();
        return new Result(true, Array.Empty<string>(), success);
    }

    public static Result Updated(params string[] success)
    {
        success = success.Append("مورد با موفقیت بروزرسانی شد.").ToArray();
        return new Result(true, Array.Empty<string>(), success);
    }

    public static Result Deleted(params string[] success)
    {
        success = success.Append("مورد با موفقیت حذف شد.").ToArray();
        return new Result(true, Array.Empty<string>(), success);
    }

    public static Result OperationSuccess(params string[] success)
    {
        success = success.Append("عملیات با موفقیت انجام شد.").ToArray();
        return new Result(true, Array.Empty<string>(), success);
    }

    public static Result FailedCreate(params string[] errors)
    {
        errors = errors.Append("مشکلی در ایجاد مورد رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<string>());
    }

    public static Result FailedUpdate(params string[] errors)
    {
        errors = errors.Append("مشکلی در بروزرسانی مورد رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<string>());
    }

    public static Result FailedDelete(params string[] errors)
    {
        errors = errors.Append("مشکلی در حذف مورد رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<string>());
    }

    public static Result OperationFailed(params string[] errors)
    {
        errors = errors.Append("مشکلی در انجام عملیات رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<string>());
    }
}
