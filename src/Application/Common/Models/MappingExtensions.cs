namespace NiceShop.Application.Common.Models;

public static class MappingExtensions
{
    public static async Task<Pagination<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int pageNumber = 1, int pageSize = 10) where TDestination : class
    {
        var count = await queryable.CountAsync();
        var items = await queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new Pagination<TDestination>(items, pageNumber, (int)Math.Ceiling(count / (double)pageSize),
            count,
            pageNumber > 1, pageNumber < (int)Math.Ceiling(count / (double)pageSize));
    }

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable,
        IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
