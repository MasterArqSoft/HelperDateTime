using HelperDateTime.Conversions;
using System.Globalization;

namespace HelperDateTimeTests.Conversions;
/// <summary>
/// Contains unit tests for the <see cref="DateConversion"/> class.
/// </summary>
public class DateConversionTests
{
    /// <summary>
    /// Tests that <see cref="DateConversion.ToShortDateFormat"/> throws an ArgumentNullException when the input date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_DateIsNull_ToShortDateFormat()
    {
        Assert.Throws<ArgumentNullException>(() => DateConversion.ToShortDateFormat(null));
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToShortDateFormat"/> returns the correct short date format for a valid date.
    /// </summary>
    [Fact]
    public void Should_ReturnShortDateFormat_When_DateIsValid()
    {
        var date = new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified);
        var result = DateConversion.ToShortDateFormat(date);
        Assert.Equal(date.ToString("d/M/yy"), result);
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToMediumDateFormat"/> throws an ArgumentNullException when the input date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_DateIsNull_ToMediumDateFormat()
    {
        Assert.Throws<ArgumentNullException>(() => DateConversion.ToMediumDateFormat(null));
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToMediumDateFormat"/> returns the correct medium date format for a valid date.
    /// </summary>
    [Fact]
    public void Should_ReturnMediumDateFormat_When_DateIsValid()
    {
        var date = new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified);
        var result = DateConversion.ToMediumDateFormat(date);
        Assert.Equal(date.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture), result);
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToLongDateFormat"/> throws an ArgumentNullException when the input date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_DateIsNull_ToLongDateFormat()
    {
        Assert.Throws<ArgumentNullException>(() => DateConversion.ToLongDateFormat(null));
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToLongDateFormat"/> returns the correct long date format for a valid date.
    /// </summary>
    [Fact]
    public void Should_ReturnLongDateFormat_When_DateIsValid()
    {
        var date = new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified);
        var result = DateConversion.ToLongDateFormat(date);
        Assert.Equal(date.ToString("MMMM dd, yyyy"), result);
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToFullDateFormat"/> throws an ArgumentNullException when the input date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_DateIsNull_ToFullDateFormat()
    {
        Assert.Throws<ArgumentNullException>(() => DateConversion.ToFullDateFormat(null));
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.ToFullDateFormat"/> returns the correct full date format for a valid date.
    /// </summary>
    [Fact]
    public void Should_ReturnFullDateFormat_When_DateIsValid()
    {
        var date = new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified);
        var result = DateConversion.ToFullDateFormat(date);
        Assert.Equal(date.ToString("dddd, MMMM dd, yyyy"), result);
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.StringToDate"/> throws an ArgumentNullException when the input string is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_StringIsNull_StringToDate()
    {
        Assert.Throws<ArgumentNullException>(() => DateConversion.StringToDate(null!));
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.StringToDate"/> correctly converts a valid date string to a <see cref="DateTime"/> object.
    /// </summary>
    [Fact]
    public void Should_ReturnDate_When_ValidString_StringToDate()
    {
        const string stringDate = "4/11/2024"; // April 11, 2024 (M/d/yyyy)
        var result = DateConversion.StringToDate(stringDate);
        Assert.Equal(new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), result.Date);
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.FormatToDate"/> throws an ArgumentNullException when any of the input arguments are null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_AnyArgumentIsNull_FormatToDate()
    {
        Assert.Throws<ArgumentNullException>(() => DateConversion.FormatToDate(null, 4, 11));
        Assert.Throws<ArgumentNullException>(() => DateConversion.FormatToDate(2024, null, 11));
        Assert.Throws<ArgumentNullException>(() => DateConversion.FormatToDate(2024, 4, null));
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.FormatToDate"/> correctly formats a valid year, month, and day into a <see cref="DateTime"/> object.
    /// </summary>
    [Fact]
    public void Should_ReturnFormattedDate_When_ArgumentsAreValid()
    {
        var result = DateConversion.FormatToDate(2024, 4, 11);
        Assert.Equal(new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), result);
    }

    /// <summary>
    /// Tests that <see cref="DateConversion.FormatToDate"/> adjusts the day when an invalid day is provided for a given month.
    /// </summary>
    [Fact]
    public void Should_AdjustDay_When_InvalidDayForMonth_FormatToDate()
    {
        // April has only 30 days
        var result = DateConversion.FormatToDate(2024, 4, 31);
        Assert.Equal(new DateTime(2024, 4, 30, 0, 0, 0, DateTimeKind.Unspecified), result);
    }
}
