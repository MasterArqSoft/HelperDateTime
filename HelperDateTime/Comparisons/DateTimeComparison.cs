using HelperDateTime.Validations;

namespace HelperDateTime.Comparisons;
/// <summary>
/// Provides methods for comparing two <see cref="DateTime"/> objects.
/// </summary>
public static class DateTimeComparison
{
    /// <summary>
    /// Determines whether the first <see cref="DateTime"/> is after the second <see cref="DateTime"/>.
    /// </summary>
    /// <param name="initialDateTime">The first <see cref="DateTime"/> to compare.</param>
    /// <param name="finalDateTime">The second <see cref="DateTime"/> to compare.</param>
    /// <returns><c>true</c> if <paramref name="initialDateTime"/> is after <paramref name="finalDateTime"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="initialDateTime"/> or <paramref name="finalDateTime"/> is <c>null</c>.</exception>
    public static bool DateTimeAfter(DateTime? initialDateTime, DateTime? finalDateTime)
    {
        HelperValidateDate.ValidateDate(initialDateTime, nameof(initialDateTime));
        HelperValidateDate.ValidateDate(finalDateTime, nameof(finalDateTime));
        return initialDateTime!.Value > finalDateTime!.Value;
    }

    /// <summary>
    /// Determines whether the first <see cref="DateTime"/> is before the second <see cref="DateTime"/>.
    /// </summary>
    /// <param name="initialDateTime">The first <see cref="DateTime"/> to compare.</param>
    /// <param name="finalDateTime">The second <see cref="DateTime"/> to compare.</param>
    /// <returns><c>true</c> if <paramref name="initialDateTime"/> is before <paramref name="finalDateTime"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="initialDateTime"/> or <paramref name="finalDateTime"/> is <c>null</c>.</exception>
    public static bool DateTimeBefore(DateTime? initialDateTime, DateTime? finalDateTime)
    {
        HelperValidateDate.ValidateDate(initialDateTime, nameof(initialDateTime));
        HelperValidateDate.ValidateDate(finalDateTime, nameof(finalDateTime));
        return initialDateTime!.Value < finalDateTime!.Value;
    }

    /// <summary>
    /// Determines whether the first <see cref="DateTime"/> is equal to the second <see cref="DateTime"/>.
    /// </summary>
    /// <param name="initialDateTime">The first <see cref="DateTime"/> to compare.</param>
    /// <param name="finalDateTime">The second <see cref="DateTime"/> to compare.</param>
    /// <returns><c>true</c> if <paramref name="initialDateTime"/> is equal to <paramref name="finalDateTime"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="initialDateTime"/> or <paramref name="finalDateTime"/> is <c>null</c>.</exception>
    public static bool DateTimeEquals(DateTime? initialDateTime, DateTime? finalDateTime)
    {
        HelperValidateDate.ValidateDate(initialDateTime, nameof(initialDateTime));
        HelperValidateDate.ValidateDate(finalDateTime, nameof(finalDateTime));
        return initialDateTime!.Value == finalDateTime!.Value;
    }
}
