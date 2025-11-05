using System;

namespace PxBunny.Result.Generator.Extensions;

internal static class StringExtensions
{
    public static string AddIndent(this string text, int indent)
    {
        if (indent < 0)
            throw new ArgumentOutOfRangeException(nameof(indent), "indent is less than zero");

        if (string.IsNullOrWhiteSpace(text))
            return text;

        var indentStr = new string(' ', indent);
        return $"{indentStr}{text.Replace("\n", $"\n{indentStr}")}";
    }
}
