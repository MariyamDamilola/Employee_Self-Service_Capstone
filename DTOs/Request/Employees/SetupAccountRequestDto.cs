namespace Employee_Self_Service_Capstone.DTOs.Request.Employees;

public class SetupAccountRequestDto
{
    public string Token { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}