namespace HelperDateTime;
/// <summary>
/// Provides utility methods for date and time operations.
/// </summary>
public static class DateQuery
{
    /// <summary>
    /// Converts the current UTC date and time to the specified local time zone.
    /// </summary>
    /// <param name="timeZoneId">The identifier of the target time zone.</param>
    /// <returns>The current date and time in the specified time zone.</returns>
    /// <exception cref="TimeZoneNotFoundException">Thrown when the specified time zone identifier is invalid.</exception>
    /// <exception cref="InvalidTimeZoneException">Thrown when the time zone data is corrupted.</exception>
    public static DateTime CurrentDateConvertUtcLocal(string timeZoneId)
    {
        // Get the current UTC date and time
        DateTime utcNow = DateTime.UtcNow;

        // Variable to hold the target time zone information
        TimeZoneInfo? ColombiaZone;

        try
        {
            // Attempt to find the specified time zone
            ColombiaZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
        catch (TimeZoneNotFoundException)
        {
            try
            {
                // Fallback to "SA Pacific Standard Time" if the specified time zone is not found
                ColombiaZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                // Fallback to UTC if "SA Pacific Standard Time" is also not found
                ColombiaZone = TimeZoneInfo.Utc;
            }
        }

        // Convert the current UTC time to the target time zone
        return TimeZoneInfo.ConvertTimeFromUtc(utcNow, ColombiaZone);
    }

    /// <summary>
    /// Determines whether the specified year is a leap year.
    /// </summary>
    /// <param name="year">The year to check. Must be a positive integer.</param>
    /// <returns><c>true</c> if the specified year is a leap year; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the year is null, zero, or negative.</exception>
    public static bool IsLeapYear(int? year)
    {
        return year == null || year <= 0 ? throw new ArgumentNullException(nameof(year), "El campo 'año' no puede tener un valor nulo, ni ser igual a 0 o un número negativo.")
                            : DateTime.IsLeapYear(year.GetValueOrDefault());
    }
}

