namespace HelperDateTime;
/// <summary>
/// Provides utility methods for working with DateTime and time zones.
/// </summary>
public static class DateTimeQuery
{
    /// <summary>
    /// Converts the current UTC time to the specified local time zone.
    /// </summary>
    /// <param name="timeZoneId">The identifier of the target time zone.</param>
    /// <returns>The current time in the specified time zone.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="timeZoneId"/> is null or empty.</exception>
    public static DateTime SystemDateTimeConvertUtcLocal(string timeZoneId)
    {
        if (string.IsNullOrWhiteSpace(timeZoneId))
        {
            throw new ArgumentNullException(nameof(timeZoneId), "El identificador de zona horaria no puede ser nulo o vacío.");
        }

        DateTime utcNow = DateTime.UtcNow;
        TimeZoneInfo targetTimeZone;

        try
        {
            targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
        catch (TimeZoneNotFoundException)
        {
            try
            {
                targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            }
            catch
            {
                targetTimeZone = TimeZoneInfo.Utc;
            }
        }

        return TimeZoneInfo.ConvertTimeFromUtc(utcNow, targetTimeZone);
    }

    /// <summary>
    /// Converts a UTC DateTime to the specified time zone.
    /// </summary>
    /// <param name="utcDateTime">The UTC DateTime to convert.</param>
    /// <param name="timeZoneId">The identifier of the target time zone.</param>
    /// <returns>The converted DateTime in the specified time zone.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="timeZoneId"/> is null or empty.</exception>
    public static DateTime ConvertUtcToTimeZone(DateTime utcDateTime, string timeZoneId)
    {
        if (string.IsNullOrWhiteSpace(timeZoneId))
        {
            throw new ArgumentNullException(nameof(timeZoneId), "El identificador de zona horaria no puede ser nulo o vacío.");
        }

        var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tz);
    }

    /// <summary>
    /// Extracts the time part (hours, minutes, seconds) from a DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime from which to extract the time part.</param>
    /// <returns>A TimeSpan representing the time part of the DateTime.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="dateTime"/> is null.</exception>
    public static TimeSpan GetTimePart(DateTime? dateTime)
    {
        HelperValidateDate.ValidateDate(dateTime, nameof(dateTime));
        return dateTime!.Value.TimeOfDay;
    }

    /// <summary>
    /// Adds a specified interval to a DateTime.
    /// </summary>
    /// <param name="interval">The interval to add. Supported values: "yyyy" (years), "m" (months), "d" (days), "h" (hours), "n" (minutes), "s" (seconds).</param>
    /// <param name="number">The number of intervals to add.</param>
    /// <param name="dateTime">The DateTime to which the interval will be added.</param>
    /// <returns>A new DateTime with the specified interval added.</returns>
    /// <exception cref="ArgumentException">Thrown when the interval is not supported.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="interval"/>, <paramref name="number"/>, or <paramref name="dateTime"/> is null.</exception>
    public static DateTime DateTimeAdd(string interval, int? number, DateTime? dateTime)
    {
        HelperValidateDate.ValidateString(interval, nameof(interval));
        HelperValidateDate.ValidateNotNull(number, nameof(number));
        HelperValidateDate.ValidateDate(dateTime, nameof(dateTime));

        return interval switch
        {
            "yyyy" => dateTime!.Value.AddYears(number!.Value),
            "m" => dateTime!.Value.AddMonths(number!.Value),
            "d" => dateTime!.Value.AddDays(number!.Value),
            "h" => dateTime!.Value.AddHours(number!.Value),
            "n" => dateTime!.Value.AddMinutes(number!.Value),
            "s" => dateTime!.Value.AddSeconds(number!.Value),
            _ => throw new ArgumentException("Intervalo no soportado. Use 'yyyy', 'm', 'd', 'h', 'n', o 's'.", nameof(interval)),
        };
    }
}
