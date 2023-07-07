using System.Reflection;

namespace StayHome.Application.Drivers;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}