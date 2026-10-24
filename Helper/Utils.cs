namespace Employee_Self_Service_Capstone.Helper;

public class Utils
{
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("Password cannot be empty");
        }

        var encryptPass = BCrypt.Net.BCrypt.HashPassword(password);
        return encryptPass;
    }
    
    
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("Password cannot be empty");
        }
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
    
    
    public static string GenerateOtp()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }
}