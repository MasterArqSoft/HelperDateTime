namespace HelperDateTime.Validations;
/// <summary>
/// Provides helper methods for validating dates, strings, and other parameters.
/// </summary>
public static class HelperValidateDate
{
    /// <summary>
    /// Validates that the provided date is not null.
    /// </summary>
    /// <param name="date">The date to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when the date is null.</exception>
    public static void ValidateDate(DateTime? date, string paramName)
    {
        if (!date.HasValue)
        {
            throw new ArgumentNullException(paramName, $"La fecha '{paramName}' no puede ser nula.");
        }
    }

    /// <summary>
    /// Validates that the provided nullable value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value being validated.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
    public static void ValidateNotNull<T>(T? value, string paramName) where T : struct
    {
        if (!value.HasValue)
        {
            throw new ArgumentNullException(paramName, $"El parámetro '{paramName}' no puede ser nulo.");
        }
    }

    /// <summary>
    /// Validates that the provided reference type value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value being validated.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
    public static void ValidateNotNull<T>(T value, string paramName) where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName, $"El parámetro '{paramName}' no puede ser nulo.");
        }
    }

    /// <summary>
    /// Validates that the provided string is not null, empty, or whitespace.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentNullException">Thrown when the string is null, empty, or whitespace.</exception>
    public static void ValidateString(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(paramName, $"El parámetro '{paramName}' no puede ser nulo o vacío.");
        }
    }

    /// <summary>
    /// Validates that the provided nullable integer is positive and greater than zero.
    /// </summary>
    /// <param name="value">The integer to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the integer is null or not positive.</exception>
    public static void ValidatePositive(int? value, string paramName)
    {
        if (!value.HasValue || value <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, $"El valor de '{paramName}' debe ser un número positivo mayor a cero.");
        }
    }

    /// <summary>
    /// Validates the provided date and applies a selector function to it.
    /// </summary>
    /// <typeparam name="TOut">The type of the result returned by the selector function.</typeparam>
    /// <param name="date">The date to validate.</param>
    /// <param name="selector">The function to apply to the validated date.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>The result of applying the selector function to the validated date.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the date is null.</exception>
    public static TOut ValidateAndReturn<TOut>(DateTime? date, Func<DateTime, TOut> selector, string paramName)
    {
        ValidateDate(date, paramName);
        return selector(date!.Value);
    }
}
