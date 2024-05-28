using System.Globalization;
using FluentResults;

namespace Domain.Shared.Extensions;

public static class StringExtension
{
    public static bool HasMinhWords(this string value, int min)
    {
        var items = value.Split(" ");
        return items.Length >= min;
    }

    public static bool HasValue(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public static long GetLongOrDefault(this string? value)
    {
        return !value.HasValue() ? 0 : long.Parse(value!);
    }

    public static string ToCamelCase(this string str, bool firstUpper = false)
    {
        var cultInfo = new CultureInfo("en-US", false).TextInfo;

        str = cultInfo.ToTitleCase(str);
        str = str.Replace(" ", "");

        if (firstUpper) str = char.ToLower(str[0]) + str[1..];

        return str;
    }

    public static bool IsValid(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public static Result<bool> IsValidResult(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public static Result<bool> IsValidNotEmpty(this string value)
    {
        return value.IsValid();
    }

    public static Result<bool> IsValidLength(this string value, int fieldMinLength, int fieldMaxLength)
    {
        return value.Length.IsBetween(fieldMinLength, fieldMaxLength);
    }
}