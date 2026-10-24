namespace Employee_Self_Service_Capstone.DTOs.Response;

public class ValidationErrorItem
{
    public string Field { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public ValidationErrorItem() { }

    public ValidationErrorItem(string field, string message)
    {
        Field = field;
        Message = message;
    }
}