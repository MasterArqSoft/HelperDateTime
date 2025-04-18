using HelperDateTime.Comparisons;

namespace HelperDateTimeTests.Comparisons;
/// <summary>
/// Contains unit tests for the <see cref="DateComparison"/> class methods.
/// </summary>
public class DateComparisonTests
{
    /// <summary>
    /// Verifies that <see cref="DateComparison.DateAfter"/> throws an <see cref="ArgumentNullException"/>
    /// when either the initial date or final date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InitialDateOrFinalDateIsNull_DateAfter()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateComparison.IsDateAfter(null, DateTime.Today));
        _ = Assert.Throws<ArgumentNullException>(() => DateComparison.IsDateAfter(DateTime.Today, null));
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.DateAfter"/> returns true when the initial date is after the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnTrue_When_InitialDateAfterFinalDate()
    {
        var result = DateComparison.IsDateAfter(DateTime.Today.AddDays(1), DateTime.Today);
        Assert.True(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.DateAfter"/> returns false when the initial date is not after the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnFalse_When_InitialDateNotAfterFinalDate()
    {
        var result = DateComparison.IsDateAfter(DateTime.Today, DateTime.Today.AddDays(1));
        Assert.False(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.IsDateBefore"/> throws an <see cref="ArgumentNullException"/>
    /// when either the initial date or final date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InitialDateOrFinalDateIsNull_DateBefore()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateComparison.IsDateBefore(null, DateTime.Today));
        _ = Assert.Throws<ArgumentNullException>(() => DateComparison.IsDateBefore(DateTime.Today, null));
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.IsDateBefore"/> returns true when the initial date is before the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnTrue_When_InitialDateBeforeFinalDate()
    {
        var result = DateComparison.IsDateBefore(DateTime.Today, DateTime.Today.AddDays(1));
        Assert.True(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.IsDateBefore"/> returns false when the initial date is not before the final date.
    /// </summary>
    [Fact]
    public void Should_ReturnFalse_When_InitialDateNotBeforeFinalDate()
    {
        var result = DateComparison.IsDateBefore(DateTime.Today.AddDays(1), DateTime.Today);
        Assert.False(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.IsDateEquals"/> throws an <see cref="ArgumentNullException"/>
    /// when either the initial date or final date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InitialDateOrFinalDateIsNull_DateEquals()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateComparison.IsDateEquals(null, DateTime.Today));
        _ = Assert.Throws<ArgumentNullException>(() => DateComparison.IsDateEquals(DateTime.Today, null));
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.IsDateEquals"/> returns true when the initial date and final date are equal.
    /// </summary>
    [Fact]
    public void Should_ReturnTrue_When_DatesAreEqual()
    {
        var today = DateTime.Today;
        var result = DateComparison.IsDateEquals(today, today);
        Assert.True(result);
    }

    /// <summary>
    /// Verifies that <see cref="DateComparison.IsDateEquals"/> returns false when the initial date and final date are different.
    /// </summary>
    [Fact]
    public void Should_ReturnFalse_When_DatesAreDifferent()
    {
        var result = DateComparison.IsDateEquals(DateTime.Today, DateTime.Today.AddDays(1));
        Assert.False(result);
    }
}
