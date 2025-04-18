using HelperDateTime.Comparisons;

namespace HelperDateTimeTests.Comparisons;
/// <summary>
/// Contains unit tests for the <see cref="DateTimeComparison"/> class methods.
/// </summary>
public class DateTimeComparisonTests
{
    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeAfter"/> throws an <see cref="ArgumentNullException"/>
    /// when either the initial or final date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InitialOrFinalDateIsNull_DatetimeAfter()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateTimeComparison.DateTimeAfter(null, DateTime.Now));
        _ = Assert.Throws<ArgumentNullException>(() => DateTimeComparison.DateTimeAfter(DateTime.Now, null));
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeAfter"/> returns true
    /// when the initial date is after the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnTrue_When_InitialDateIsAfterFinalDate()
    {
        var result = DateTimeComparison.DateTimeAfter(DateTime.Now.AddHours(2), DateTime.Now);
        Assert.True(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeAfter"/> returns false
    /// when the initial date is not after the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnFalse_When_InitialDateIsNotAfterFinalDate()
    {
        var result = DateTimeComparison.DateTimeAfter(DateTime.Now, DateTime.Now.AddHours(2));
        Assert.False(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeBefore"/> throws an <see cref="ArgumentNullException"/>
    /// when either the initial or final date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InitialOrFinalDateIsNull_DatetimeBefore()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateTimeComparison.DateTimeBefore(null, DateTime.Now));
        _ = Assert.Throws<ArgumentNullException>(() => DateTimeComparison.DateTimeBefore(DateTime.Now, null));
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeBefore"/> returns true
    /// when the initial date is before the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnTrue_When_InitialDateIsBeforeFinalDate()
    {
        var result = DateTimeComparison.DateTimeBefore(DateTime.Now, DateTime.Now.AddHours(2));
        Assert.True(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeBefore"/> returns false
    /// when the initial date is not before the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnFalse_When_InitialDateIsNotBeforeFinalDate()
    {
        var result = DateTimeComparison.DateTimeBefore(DateTime.Now.AddHours(2), DateTime.Now);
        Assert.False(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeEquals"/> throws an <see cref="ArgumentNullException"/>
    /// when either the initial or final date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InitialOrFinalDateIsNull_DatetimeEquals()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateTimeComparison.DateTimeEquals(null, DateTime.Now));
        _ = Assert.Throws<ArgumentNullException>(() => DateTimeComparison.DateTimeEquals(DateTime.Now, null));
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeEquals"/> returns true
    /// when the initial and final dates are exactly equal.
    /// </summary>
    [Fact]
    public void Should_ReturnTrue_When_DatesAreExactlyEqual()
    {
        var now = DateTime.Now;
        var result = DateTimeComparison.DateTimeEquals(now, now);
        Assert.True(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateTimeComparison.DateTimeEquals"/> returns false
    /// when the initial and final dates are different.
    /// </summary>
    [Fact]
    public void Should_ReturnFalse_When_DatesAreDifferent()
    {
        var result = DateTimeComparison.DateTimeEquals(DateTime.Now, DateTime.Now.AddSeconds(10));
        Assert.False(result);
    }
}
