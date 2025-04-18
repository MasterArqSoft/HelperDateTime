using HelperDateTime.Conversions;
using System.Globalization;

namespace HelperDateTimeTests.Conversions;
/// <summary>
/// Unit tests for the <see cref="DateTimeConversions"/> class.
/// </summary>
public class DateTimeConversionsTests
{
    /// <summary>
    /// Tests that <see cref="DateTimeConversions.ToDateTime(DateTime?, DateTime?)"/> throws an <see cref="ArgumentNullException"/>
    /// when either the date or time parameter is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_DateOrTimeIsNull_ToDateTime()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.ToDateTime(null, DateTime.Now));
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.ToDateTime(DateTime.Now, null));
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.ToDateTime(DateTime?, DateTime?)"/> correctly combines a valid date and time into a single <see cref="DateTime"/> object.
    /// </summary>
    [Fact]
    public void Should_CombineDateAndTime_When_ValidInputs()
    {
        var date = new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified);
        var time = new DateTime(1, 1, 1, 14, 30, 45, DateTimeKind.Unspecified); // Only time
        var combined = DateTimeConversions.ToDateTime(date, time);

        Assert.Equal(2024, combined.Year);
        Assert.Equal(4, combined.Month);
        Assert.Equal(11, combined.Day);
        Assert.Equal(14, combined.Hour);
        Assert.Equal(30, combined.Minute);
        Assert.Equal(45, combined.Second);
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.DateTimeToString(DateTime?)"/> throws an <see cref="ArgumentNullException"/>
    /// when the date parameter is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_DateIsNull_DateTimeToString()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.DateTimeToString(null));
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.DateTimeToString(DateTime?)"/> returns a correctly formatted string
    /// when a valid <see cref="DateTime"/> is provided.
    /// </summary>
    [Fact]
    public void Should_ReturnFormattedString_When_DateIsValid_DateTimeToString()
    {
        var date = new DateTime(2024, 4, 11, 14, 30, 45, DateTimeKind.Unspecified);
        var result = DateTimeConversions.DateTimeToString(date);

        Assert.Equal(date.ToString("MMMM dd, yyyy HH:mm:ss", CultureInfo.InvariantCulture), result);
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.StringToDateTime(string)"/> throws an <see cref="ArgumentNullException"/>
    /// when the input string is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_StringIsNull_StringToDateTime()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.StringToDateTime(null!));
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.StringToDateTime(string)"/> correctly parses a valid date string
    /// into a <see cref="DateTime"/> object.
    /// </summary>
    [Fact]
    public void Should_ReturnDateTime_When_ValidString_StringToDateTime()
    {
        const string stringDate = "May 15, 2024 10:30:45";
        var parsedDate = DateTimeConversions.StringToDateTime(stringDate);

        Assert.Equal(2024, parsedDate.Year);
        Assert.Equal(5, parsedDate.Month);
        Assert.Equal(15, parsedDate.Day);
        Assert.Equal(10, parsedDate.Hour);
        Assert.Equal(30, parsedDate.Minute);
        Assert.Equal(45, parsedDate.Second);
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.FormatToDateTime(int?, int?, int?, int?, int?, int?)"/> throws an <see cref="ArgumentNullException"/>
    /// when any of the input arguments are null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_AnyArgumentIsNull_FormatToDateTime()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.FormatToDateTime(null, 4, 11, 14, 30, 45));
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.FormatToDateTime(2024, null, 11, 14, 30, 45));
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.FormatToDateTime(2024, 4, null, 14, 30, 45));
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.FormatToDateTime(2024, 4, 11, null, 30, 45));
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.FormatToDateTime(2024, 4, 11, 14, null, 45));
        Assert.Throws<ArgumentNullException>(() => DateTimeConversions.FormatToDateTime(2024, 4, 11, 14, 30, null));
    }

    /// <summary>
    /// Tests that <see cref="DateTimeConversions.FormatToDateTime(int?, int?, int?, int?, int?, int?)"/> correctly creates
    /// a <see cref="DateTime"/> object when all arguments are valid.
    /// </summary>
    [Fact]
    public void Should_ReturnDateTime_When_ArgumentsAreValid_FormatToDateTime()
    {
        var result = DateTimeConversions.FormatToDateTime(2024, 4, 11, 14, 30, 45);

        Assert.Equal(new DateTime(2024, 4, 11, 14, 30, 45, DateTimeKind.Unspecified), result);
    }
}
