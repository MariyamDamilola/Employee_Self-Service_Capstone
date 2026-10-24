using Employee_Self_Service_Capstone.DTOs.Request.Common;
using Employee_Self_Service_Capstone.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Extension;

public static class QueryableExtensions
{
    public static async Task<ApiResponse<List<T>>> ToPaginatedListAsync<T>(
        this IQueryable<T> source,
        PaginationFilter filter,
        CancellationToken cancellationToken = default)
    {
        var totalCount = await source.CountAsync(cancellationToken);

        var items = await source
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync(cancellationToken);

        var paginationMetadata = new PaginationMetadata(filter.PageNumber, filter.PageSize, totalCount);

        return ApiResponse<List<T>>.Success(items, paginationMetadata);
    }
}