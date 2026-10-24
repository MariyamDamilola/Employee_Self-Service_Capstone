namespace Employee_Self_Service_Capstone.Helper;

public class EstacodeCalculator
{
    public static int CalculateEligibleDays(DateTime departureDate, DateTime returnDate)
    {
        if (returnDate < departureDate)
        {
            throw new Exception("Return date cannot be earlier than departure date.");
        }

        return (returnDate.Date - departureDate.Date).Days + 1;
    }

    public static decimal CalculateTotalAllowance(int eligibleDays, decimal dailyRate)
    {
        if (eligibleDays < 1)
        {
            throw new Exception("Eligible days must be at least 1.");
        }

        if (dailyRate < 0)
        {
            throw new Exception("Daily rate cannot be negative.");
        }

        return eligibleDays * dailyRate;
    }
}