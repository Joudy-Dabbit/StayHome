namespace Domain;

public class ConstValues
{
    public const int ExpireAccessTokenMinute = 2;
    public static DateTime AccessExpireDateTime = DateTime.UtcNow.AddDays(ExpireAccessTokenMinute);
    public const int ExpireRefreshTokenDay = 60;
    public static readonly string WwwrootDir = "wwwroot";
    public static readonly string Seed = "Seed";
    public static readonly string StayHomeJpg = "StayHome.jpg";
    public class UserType
    {
        public const string Driver = "Driver";
        public const string Employee = "Employee";
        public const string Customer = "Customer";
    }
    
    public static class AppClaims
    {
        public const string Type = "Type";
    }
}