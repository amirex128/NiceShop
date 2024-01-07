namespace NiceShop.Application.Common.Models;

public class Pagination<T>(
    IReadOnlyCollection<T>? items,
    int pageNumber,
    int totalPages,
    int totalCount,
    bool hasPreviousPage,
    bool hasNextPage)
{
    public IReadOnlyCollection<T>? Items { get; set; } = items;
    public int PageNumber { get; set; } = pageNumber;
    public int TotalPages { get; set; } = totalPages;
    public int TotalCount { get; set; } = totalCount;
    public bool HasPreviousPage { get; set; } = hasPreviousPage;
    public bool HasNextPage { get; set; } = hasNextPage;
}
