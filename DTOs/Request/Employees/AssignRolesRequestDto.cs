namespace Employee_Self_Service_Capstone.DTOs.Request.Employees;

public class AssignRolesRequestDto
{
    public List<int> RoleIds { get; set; } = new();
}