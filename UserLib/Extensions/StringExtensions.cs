namespace UserLib.Extensions;
public static class StringExtensions
{
    public static string ToSlug(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        return input.ToLowerInvariant().Replace(" ", "-");
    }
}
