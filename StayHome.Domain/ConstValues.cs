namespace Domain;

public class ConstValues
{
    public const int ExpireAccessTokenMinute = 2;
    public static DateTime AccessExpireDateTime = DateTime.UtcNow.AddDays(ExpireAccessTokenMinute);

    public class UserType
    {
        public const string Driver = "Driver";
        public const string Employee = "Employee";
        public const string Customer = "Customer";
    }
    
    public class AppRoles
    {
        public const string Admin = "Admin";
        public const string Shop = "Shop";
        public const string Customer = "Customer";
        public const string Driver = "Driver";
    }

    public static class AppClaims
    {
        public const string Type = "Type";
    }
}