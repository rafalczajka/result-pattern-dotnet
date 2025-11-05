using System.Linq;
using System.Reflection;

namespace PxBunny.Result.Generator.Extensions;

internal static class AssemblyExtensions
{
    public static string? GetMetadata(this Assembly assembly, string key) =>
        assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(a => a.Key == key)?.Value;
}
