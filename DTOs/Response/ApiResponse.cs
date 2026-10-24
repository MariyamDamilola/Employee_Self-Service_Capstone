namespace Employee_Self_Service_Capstone.DTOs.Response;
   
public class ApiResponse
{
    public string ResponseCode { get; set; } = "00";
    public string ResponseMessage { get; set; } = "Success";
    public object? Data { get; set; }
    public PaginationMetadata? Pagination { get; set; }
    public List<ValidationErrorItem>? Errors { get; set; }

    public static ApiResponse Success(string message = "Operation completed successfully.", string responseCode = "00")
    {
        return new ApiResponse
        {
            ResponseCode = responseCode,
            ResponseMessage = message
        };
    }

    public static ApiResponse Success(object? data, string message = "Success", string responseCode = "00")
    {
        return new ApiResponse
        {
            ResponseCode = responseCode,
            ResponseMessage = message,
            Data = data
        };
    }

    public static ApiResponse Failure(string message, string responseCode = "99", List<ValidationErrorItem>? errors = null)
    {
        return new ApiResponse
        {
            ResponseCode = responseCode,
            ResponseMessage = message,
            Errors = errors ?? new List<ValidationErrorItem>()
        };
    }
}

// 2. Generic version: inherits from non-generic to share properties, strongly types Data
public class ApiResponse<T> : ApiResponse
{
    public new T? Data { get; set; }

    public static ApiResponse<T> Success(T data, string message = "Success", string responseCode = "00")
    {
        return new ApiResponse<T>
        {
            ResponseCode = responseCode,
            ResponseMessage = message,
            Data = data
        };
    }

    public static ApiResponse<T> Success(T data, PaginationMetadata pagination, string message = "Success", string responseCode = "00")
    {
        return new ApiResponse<T>
        {
            ResponseCode = responseCode,
            ResponseMessage = message,
            Data = data,
            Pagination = pagination
        };
    }

    public new static ApiResponse<T> Failure(string message, string responseCode = "99", List<ValidationErrorItem>? errors = null)
    {
        return new ApiResponse<T>
        {
            ResponseCode = responseCode,
            ResponseMessage = message,
            Data = default,
            Errors = errors ?? new List<ValidationErrorItem>()
        };
    }
}