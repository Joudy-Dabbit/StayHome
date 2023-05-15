namespace StayHome.Application.Dashboard.Core.ExtensionMethods;

public static class HelperMethods
{
    public static Guid? StringToGuid(this string source) =>
        source is null ? new Guid ("00000000-0000-0000-0000-000000000000") : Guid.Parse(source);
}