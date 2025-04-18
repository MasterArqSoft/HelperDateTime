using HelperDateTime.Queries;

namespace HelperDateTimeTests.Queries;
/// <summary>
/// Unit tests for the <see cref="DateTimeQuery"/> class.
/// </summary>
public class DateTimeQueryTests
{
    /// <summary>
    /// Tests that <see cref="DateTimeQuery.SystemDateTimeConvertUtcLocal(string)"/>
    /// returns the current system date and time in the specified time zone.
    /// </summary>
    [Fact]
    public void Should_ReturnCurrentSystemDateTime_When_CallingSystemDateTime()
    {
        var systemDate = DateTimeQuery.SystemDateTimeConvertUtcLocal("America/Bogota");
        Assert.True(systemDate <= DateTime.Now);
    }

    /// <summary>
    /// Tests that <see cref="DateTimeQuery.GetTimePart(DateTime?)"/> throws an exception
    /// when the input date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_DateIsNull_GetTimePart()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeQuery.GetTimePart(null));
    }

    /// <summary>
    /// Tests that <see cref="DateTimeQuery.GetTimePart(DateTime?)"/> returns the correct
    /// time part of a valid date.
    /// </summary>
    [Fact]
    public void Should_ReturnCorrectTimePart_When_DateIsValid()
    {
        var date = new DateTime(2024, 4, 11, 14, 30, 45, DateTimeKind.Unspecified);
        var timePart = DateTimeQuery.GetTimePart(date);
        Assert.Equal(new TimeSpan(14, 30, 45), timePart);
    }

    /// <summary>
    /// Tests that <see cref="DateTimeQuery.DateTimeAdd(string, int, DateTime)"/> correctly
    /// adds a specified time interval to a date when the interval is valid.
    /// </summary>
    /// <param name="interval">The time interval to add (e.g., "yyyy", "m", "d", "h", "n", "s").</param>
    /// <param name="number">The number of intervals to add.</param>
    [Theory]
    [InlineData("yyyy", 2)]
    [InlineData("m", 5)]
    [InlineData("d", 10)]
    [InlineData("h", 3)]
    [InlineData("n", 15)]
    [InlineData("s", 20)]
    public void Should_AddTimeInterval_When_ValidInterval(string interval, int number)
    {
        var date = new DateTime(2024, 4, 11, 14, 0, 0, 0, DateTimeKind.Unspecified);
        var result = DateTimeQuery.DateTimeAdd(interval, number, date);
        Assert.NotEqual(date, result);
    }

    /// <summary>
    /// Tests that <see cref="DateTimeQuery.DateTimeAdd(string, int, DateTime)"/> throws
    /// an exception when the interval is invalid.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InvalidIntervalInDateTimeAdd()
    {
        var date = new DateTime(2024, 4, 11, 0, 0, 0, DateTimeKind.Unspecified);
        Assert.Throws<ArgumentException>(() => DateTimeQuery.DateTimeAdd("invalid", 5, date));
    }

    /// <summary>
    /// Tests that <see cref="DateTimeQuery.DateTimeAdd(string, int, DateTime)"/> throws
    /// an exception when any of the arguments are null.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_ArgumentsAreNull_DateTimeAdd()
    {
        Assert.Throws<ArgumentNullException>(() => DateTimeQuery.DateTimeAdd(null!, 1, DateTime.Now));
        Assert.Throws<ArgumentNullException>(() => DateTimeQuery.DateTimeAdd("h", null, DateTime.Now));
        Assert.Throws<ArgumentNullException>(() => DateTimeQuery.DateTimeAdd("h", 1, null));
    }
}
