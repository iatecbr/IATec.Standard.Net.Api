namespace Domain.Shared.Extensions;

public static class IntExtension
{
    public static bool IsBetween(this int num,
        int min,
        int max,
        bool includeMin = true,
        bool includeMax = true)
    {
        return IsGreaterThan(num, min, includeMin) && IsLessThan(num, max, includeMax);
    }

    public static bool IsGreaterThan(int value, int minValue, bool includeMin)
    {
        return (includeMin && value >= minValue) || value > minValue;
    }

    public static bool IsLessThan(int value, int maxValue, bool includeMax)
    {
        return (includeMax && value <= maxValue) || value < maxValue;
    }

    public static int GetAge(this DateTime? birthDate)
    {
        if (birthDate == null) return 0;

        return new DateTime(DateTime.Now.Subtract((DateTime)birthDate).Ticks).Year - 1;
    }

    public static int GetAge(this string? birthDate)
    {
        if (birthDate == null) return 0;

        try
        {
#pragma warning disable CA1806
            DateTime.TryParse(birthDate, out var birthDateParsed);
#pragma warning restore CA1806

            return new DateTime(DateTime.Now.Subtract(birthDateParsed).Ticks).Year - 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}