﻿using NiceShop.Domain.Common;

namespace NiceShop.Application.AI.Common.Models;

public static class MappingExtensions
{
    public static async Task<Pagination<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int pageNumber = 1, int pageSize = 10) where TDestination : BaseEntity
    {
        var count = await queryable.CountAsync();
        var items = await queryable
            .OrderByDescending(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new Pagination<TDestination>(items, pageNumber, (int)Math.Ceiling(count / (double)pageSize),
            count,
            pageNumber > 1, pageNumber < (int)Math.Ceiling(count / (double)pageSize));
    }

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable,
        IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
