namespace NiceShop.Application.AI.Common.Models;

public class Result
{
    public Result(bool succeeded, IEnumerable<object> errors, IEnumerable<object> success)
    {
        Succeeded = succeeded;
        ErrorMessages = errors.ToArray();
        SuccessMessages = success.ToArray();
    }

    public bool Succeeded { get; init; }
    public object[] SuccessMessages { get; init; }
    public object[] ErrorMessages { get; init; }

    public object? ResultObject { get; set; }

    public Result WithObject(object? resultObject)
    {
        ResultObject = resultObject;
        return this;
    }

    public static Result Created(params object[] success)
    {
        success = success.Append("مورد با موفقیت ایجاد شد.").ToArray();
        return new Result(true, Array.Empty<object>(), success);
    }

    public static Result Updated(params object[] success)
    {
        success = success.Append("مورد با موفقیت بروزرسانی شد.").ToArray();
        return new Result(true, Array.Empty<object>(), success);
    }

    public static Result Deleted(params object[] success)
    {
        success = success.Append("مورد با موفقیت حذف شد.").ToArray();
        return new Result(true, Array.Empty<object>(), success);
    }

    public static Result OperationSuccess(params object[] success)
    {
        success = success.Append("عملیات با موفقیت انجام شد.").ToArray();
        return new Result(true, Array.Empty<object>(), success);
    }

    public static Result FailedCreate(params object[] errors)
    {
        errors = errors.Append("مشکلی در ایجاد مورد رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<object>());
    }

    public static Result FailedUpdate(params object[] errors)
    {
        errors = errors.Append("مشکلی در بروزرسانی مورد رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<object>());
    }

    public static Result FailedDelete(params object[] errors)
    {
        errors = errors.Append("مشکلی در حذف مورد رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<object>());
    }

    public static Result OperationFailed(params object[] errors)
    {
        errors = errors.Append("مشکلی در انجام عملیات رخ داده است.").ToArray();
        return new Result(false, errors, Array.Empty<object>());
    }
}
