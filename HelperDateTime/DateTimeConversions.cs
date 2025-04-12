using System.Globalization;

namespace HelperDateTime;
/// <summary>
/// Provides utility methods for converting and formatting DateTime objects.
/// </summary>
public static class DateTimeConversions
{
    /// <summary>
    /// Combines a date and a time into a single <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="date">The date part of the <see cref="DateTime"/>.</param>
    /// <param name="dateTime">The time part of the <see cref="DateTime"/>.</param>
    /// <returns>A <see cref="DateTime"/> object with the specified date and time.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="date"/> or <paramref name="dateTime"/> is null.</exception>
    public static DateTime ToDateTime(DateTime? date, DateTime? dateTime)
    {
        HelperValidateDate.ValidateDate(date, nameof(date));
        HelperValidateDate.ValidateDate(dateTime, nameof(dateTime));

        return new DateTime(
            date!.Value!.Year, date.Value!.Month, date.Value!.Day,
            dateTime!.Value!.Hour, dateTime!.Value!.Minute, dateTime!.Value!.Second, DateTimeKind.Unspecified
        );
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object to its string representation.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> to convert.</param>
    /// <returns>A string representation of the <see cref="DateTime"/> in the format "MMMM dd, yyyy HH:mm:ss".</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="dateTime"/> is null.</exception>
    public static string DateTimeToString(DateTime? dateTime)
    {
        HelperValidateDate.ValidateDate(dateTime, nameof(dateTime));
        return dateTime!.Value.ToString("MMMM dd, yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Parses a string representation of a date and time into a <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="stringDate">The string representation of the date and time.</param>
    /// <returns>A <see cref="DateTime"/> object parsed from the string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="stringDate"/> is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if <paramref name="stringDate"/> is not in a valid format.</exception>
    public static DateTime StringToDateTime(string stringDate)
    {
        HelperValidateDate.ValidateString(stringDate, nameof(stringDate));
        return DateTime.Parse(stringDate, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Creates a <see cref="DateTime"/> object from individual date and time components.
    /// </summary>
    /// <param name="year">The year component.</param>
    /// <param name="month">The month component.</param>
    /// <param name="day">The day component.</param>
    /// <param name="hour">The hour component.</param>
    /// <param name="minute">The minute component.</param>
    /// <param name="second">The second component.</param>
    /// <returns>A <see cref="DateTime"/> object with the specified components.</returns>
    /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null.</exception>
    public static DateTime FormatToDateTime(int? year, int? month, int? day, int? hour, int? minute, int? second)
    {
        HelperValidateDate.ValidateNotNull(year, nameof(year));
        HelperValidateDate.ValidateNotNull(month, nameof(month));
        HelperValidateDate.ValidateNotNull(day, nameof(day));
        HelperValidateDate.ValidateNotNull(hour, nameof(hour));
        HelperValidateDate.ValidateNotNull(minute, nameof(minute));
        HelperValidateDate.ValidateNotNull(second, nameof(second));

        return new DateTime(year!.Value, month!.Value, day!.Value, hour!.Value, minute!.Value, second!.Value, DateTimeKind.Unspecified);
    }
}
