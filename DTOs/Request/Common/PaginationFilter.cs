namespace Employee_Self_Service_Capstone.DTOs.Request.Common;

public class PaginationFilter
{
    private const int MaxPageSize = 100;
    private int _pageSize = 20;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : (value < 1 ? 1 : value);
    }

    public string? SearchTerm { get; set; }
}