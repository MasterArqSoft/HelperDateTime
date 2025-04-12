namespace HelperDateTime;
/// <summary>
/// Provides methods for comparing and validating dates.
/// </summary>
public static class DateConversion
{
    /// <summary>
    /// Determines whether the initial date is after the final date.
    /// </summary>
    /// <param name="initialDate">The initial date to compare.</param>
    /// <param name="finalDate">The final date to compare against.</param>
    /// <returns><c>true</c> if the initial date is after the final date; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="initialDate"/> or <paramref name="finalDate"/> is null.</exception>
    public static bool DateAfter(DateTime? initialDate, DateTime? finalDate)
    {
        HelperValidateDate.ValidateDate(initialDate, nameof(initialDate));
        HelperValidateDate.ValidateDate(finalDate, nameof(finalDate));
        return initialDate!.Value > finalDate!.Value;
    }

    /// <summary>
    /// Determines whether the initial date is before the final date.
    /// </summary>
    /// <param name="initialDate">The initial date to compare.</param>
    /// <param name="finalDate">The final date to compare against.</param>
    /// <returns><c>true</c> if the initial date is before the final date; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="initialDate"/> or <paramref name="finalDate"/> is null.</exception>
    public static bool DateBefore(DateTime? initialDate, DateTime? finalDate)
    {
        HelperValidateDate.ValidateDate(initialDate, nameof(initialDate));
        HelperValidateDate.ValidateDate(finalDate, nameof(finalDate));
        return initialDate!.Value < finalDate!.Value;
    }

    /// <summary>
    /// Determines whether the initial date is equal to the final date.
    /// </summary>
    /// <param name="initialDate">The initial date to compare.</param>
    /// <param name="finalDate">The final date to compare against.</param>
    /// <returns><c>true</c> if the initial date is equal to the final date; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="initialDate"/> or <paramref name="finalDate"/> is null.</exception>
    public static bool DateEquals(DateTime? initialDate, DateTime? finalDate)
    {
        HelperValidateDate.ValidateDate(initialDate, nameof(initialDate));
        HelperValidateDate.ValidateDate(finalDate, nameof(finalDate));
        return initialDate!.Value.Date == finalDate!.Value.Date;
    }
}
