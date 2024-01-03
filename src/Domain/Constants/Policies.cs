namespace NiceShop.Domain.Constants;

public abstract class ACL
{
    public const string Administrator = nameof(Administrator);
    public const string CanCreate = nameof(CanCreate);
    public const string CanUpdate = nameof(CanUpdate);
    public const string CanDelete = nameof(CanDelete);
    public const string CanGet = nameof(CanGet);
    public const string CanGetAll = nameof(CanGetAll);
}
