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
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="timeZoneId"/> is null or empty.</exception>
    public static DateTime CurrentDateConvertUtcLocal(string timeZoneId)
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
    /// Determines whether the specified year is a leap year.
    /// </summary>
    /// <param name="year">The year to check.</param>
    /// <returns><c>true</c> if the year is a leap year; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="year"/> is not positive.</exception>
    public static bool IsLeapYear(int? year)
    {
        ValidatePositive(year, nameof(year));
        return DateTime.IsLeapYear(year!.Value);
    }

    /// <summary>
    /// Calculates the number of days between two dates.
    /// </summary>
    /// <param name="date1">The start date.</param>
    /// <param name="date2">The end date.</param>
    /// <returns>The number of days between <paramref name="date1"/> and <paramref name="date2"/>. Returns 0 if <paramref name="date1"/> is later than <paramref name="date2"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either date is null.</exception>
    public static int DaysDifferenceFromDate(DateTime? date1, DateTime? date2)
    {
        ValidateDate(date1, nameof(date1));
        ValidateDate(date2, nameof(date2));

        return date1 > date2 ? 0 : (date2!.Value - date1!.Value).Days;
    }

    /// <summary>
    /// Gets the number of days in a specific month of a specific year.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <returns>The number of days in the specified month and year.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="year"/> or <paramref name="month"/> is null.</exception>
    public static int DaysInMonth(int? year, int? month)
    {
        ValidateNotNull(year, nameof(year));
        ValidateNotNull(month, nameof(month));

        return DateTime.DaysInMonth(year!.Value, month!.Value);
    }

    /// <summary>
    /// Gets the day of the month from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The day of the month.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static int GetDay(DateTime? date)
    {
        return ValidateAndReturn(date, d => d.Day, nameof(date));
    }

    /// <summary>
    /// Gets the month from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The month.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static int GetMonth(DateTime? date)
    {
        return ValidateAndReturn(date, d => d.Month, nameof(date));
    }

    /// <summary>
    /// Gets the year from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The year.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static int GetYear(DateTime? date)
    {
        return ValidateAndReturn(date, d => d.Year, nameof(date));
    }

    /// <summary>
    /// Gets the day of the year from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The day of the year.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static int GetDayOfYear(DateTime? date)
    {
        return ValidateAndReturn(date, d => d.DayOfYear, nameof(date));
    }

    /// <summary>
    /// Gets the day of the week from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The day of the week as an integer (1 for Sunday, 7 for Saturday).</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static int GetDayOfWeek(DateTime? date)
    {
        return ValidateAndReturn(date, d => (int)d.DayOfWeek + 1, nameof(date));
    }

    /// <summary>
    /// Counts the number of occurrences of a specific day of the week between two dates.
    /// </summary>
    /// <param name="dayOfWeek">The day of the week to count (1 for Sunday, 7 for Saturday).</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>The number of occurrences of the specified day of the week.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static int GetNumDayOfWeekBetweenDates(int? dayOfWeek, DateTime? startDate, DateTime? endDate)
    {
        ValidateNotNull(dayOfWeek, nameof(dayOfWeek));
        ValidateDate(startDate, nameof(startDate));
        ValidateDate(endDate, nameof(endDate));

        if (startDate > endDate)
        {
            return 0;
        }

        int totalDays = DaysDifferenceFromDate(startDate, endDate);
        int fullWeeks = totalDays / 7;
        int remainingDays = totalDays % 7;

        int startDay = GetDayOfWeek(startDate);
        int adjustedDay = dayOfWeek!.Value;

        if (adjustedDay < startDay)
        {
            adjustedDay += 7;
        }

        if (adjustedDay - startDay < remainingDays)
        {
            fullWeeks++;
        }

        return fullWeeks;
    }

    /// <summary>
    /// Gets the date of the next day from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The next day's date.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static DateTime Tomorrow(DateTime? date)
    {
        return ValidateAndReturn(date, d => d.AddDays(1), nameof(date));
    }

    /// <summary>
    /// Gets the date of the previous day from the specified date.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>The previous day's date.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    public static DateTime Yesterday(DateTime? date)
    {
        return ValidateAndReturn(date, d => d.AddDays(-1), nameof(date));
    }

    /// <summary>
    /// Adds a specified interval to a date.
    /// </summary>
    /// <param name="interval">The interval to add ('yyyy' for years, 'm' for months, 'd' for days).</param>
    /// <param name="number">The number of intervals to add.</param>
    /// <param name="date">The date to add the interval to.</param>
    /// <returns>The resulting date after adding the interval.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the interval is not supported.</exception>
    public static DateTime DateAdd(string interval, int? number, DateTime? date)
    {
        ValidateNotNull(interval, nameof(interval));
        ValidateNotNull(number, nameof(number));
        ValidateDate(date, nameof(date));

        return interval switch
        {
            "yyyy" => date!.Value.AddYears(number!.Value),
            "m" => date!.Value.AddMonths(number!.Value),
            "d" => date!.Value.AddDays(number!.Value),
            _ => throw new ArgumentException("Intervalo no soportado. Use 'yyyy', 'm', o 'd'.", nameof(interval)),
        };
    }

    #region Private Helpers

    /// <summary>
    /// Validates that the date is not null.
    /// </summary>
    /// <param name="date">The date to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    private static void ValidateDate(DateTime? date, string paramName)
    {
        if (!date.HasValue)
        {
            throw new ArgumentNullException(paramName, $"La fecha '{paramName}' no puede ser nula.");
        }
    }

    /// <summary>
    /// Validates that a nullable value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    private static void ValidateNotNull<T>(T? value, string paramName) where T : struct
    {
        if (!value.HasValue)
        {
            throw new ArgumentNullException(paramName, $"El parámetro '{paramName}' no puede ser nulo.");
        }
    }

    /// <summary>
    /// Validates that a reference type value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    private static void ValidateNotNull<T>(T value, string paramName) where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName, $"El parámetro '{paramName}' no puede ser nulo.");
        }
    }

    /// <summary>
    /// Validates that a nullable integer is positive.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is not positive.</exception>
    private static void ValidatePositive(int? value, string paramName)
    {
        if (!value.HasValue || value <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, $"El valor de '{paramName}' debe ser un número positivo mayor a cero.");
        }
    }

    /// <summary>
    /// Validates a date and applies a selector function to it.
    /// </summary>
    /// <typeparam name="TOut">The type of the result.</typeparam>
    /// <param name="date">The date to validate.</param>
    /// <param name="selector">The function to apply to the date.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>The result of applying the selector function to the date.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null.</exception>
    private static TOut ValidateAndReturn<TOut>(DateTime? date, Func<DateTime, TOut> selector, string paramName)
    {
        ValidateDate(date, paramName);
        return selector(date!.Value);
    }

    #endregion
}
