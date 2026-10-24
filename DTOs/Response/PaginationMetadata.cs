namespace Employee_Self_Service_Capstone.DTOs.Response;

public class PaginationMetadata
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }

    public PaginationMetadata() { }

    public PaginationMetadata(int pageNumber, int pageSize, int totalCount)
    {
        PageNumber = pageNumber;
        PageSize = pageSize > 100 ? 100 : pageSize; 
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)(PageSize > 0 ? PageSize : 1));
    }
}