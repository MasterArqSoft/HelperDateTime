using System.Globalization;

namespace HelperDateTime;
/// <summary>
/// Provides methods for formatting and parsing dates.
/// </summary>
public static class DateComparison
{
    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> to a short date format string (d/M/yy).
    /// </summary>
    /// <param name="date">The nullable date to format.</param>
    /// <returns>A string representing the date in short format.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the date is null.</exception>
    public static string ToShortDateFormat(DateTime? date)
    {
        HelperValidateDate.ValidateDate(date, nameof(date));
        return date!.Value.ToString("d/M/yy", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> to a medium date format string (MMM dd, yyyy).
    /// </summary>
    /// <param name="date">The nullable date to format.</param>
    /// <returns>A string representing the date in medium format.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the date is null.</exception>
    public static string ToMediumDateFormat(DateTime? date)
    {
        HelperValidateDate.ValidateDate(date, nameof(date));
        return date!.Value.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> to a long date format string (MMMM dd, yyyy).
    /// </summary>
    /// <param name="date">The nullable date to format.</param>
    /// <returns>A string representing the date in long format.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the date is null.</exception>
    public static string ToLongDateFormat(DateTime? date)
    {
        HelperValidateDate.ValidateDate(date, nameof(date));
        return date!.Value.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> to a full date format string (dddd, MMMM dd, yyyy).
    /// </summary>
    /// <param name="date">The nullable date to format.</param>
    /// <returns>A string representing the date in full format.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the date is null.</exception>
    public static string ToFullDateFormat(DateTime? date)
    {
        HelperValidateDate.ValidateDate(date, nameof(date));
        return date!.Value.ToString("dddd, MMMM dd, yyyy", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Parses a date string into a <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="stringDate">The date string to parse.</param>
    /// <returns>A <see cref="DateTime"/> object representing the parsed date.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the stringDate is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if the stringDate is not in a valid format.</exception>
    public static DateTime StringToDate(string stringDate)
    {
        HelperValidateDate.ValidateString(stringDate, nameof(stringDate));
        return DateTime.Parse(stringDate, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Creates a <see cref="DateTime"/> object from year, month, and day values.
    /// </summary>
    /// <param name="year">The year component of the date.</param>
    /// <param name="month">The month component of the date.</param>
    /// <param name="day">The day component of the date.</param>
    /// <returns>A <see cref="DateTime"/> object representing the specified date.</returns>
    /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameters are out of range for a valid date.</exception>
    public static DateTime FormatToDate(int? year, int? month, int? day)
    {
        HelperValidateDate.ValidateNotNull(year, nameof(year));
        HelperValidateDate.ValidateNotNull(month, nameof(month));
        HelperValidateDate.ValidateNotNull(day, nameof(day));

        int y = year!.Value;
        int m = month!.Value;
        int d = Math.Min(day!.Value, DateTime.DaysInMonth(y, m));

        return new DateTime(y, m, d, 0, 0, 0, DateTimeKind.Local);
    }
}
