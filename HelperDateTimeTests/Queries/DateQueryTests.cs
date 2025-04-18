using HelperDateTime.Queries;

namespace HelperDateTimeTests.Queries;
/// <summary>
/// Unit tests for the <see cref="DateQuery"/> class.
/// </summary>
public class DateQueryTests
{
    /// <summary>
    /// Verifies that an exception is thrown when both dates are null in <see cref="DateQuery.DaysDifferenceFromDate"/>.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_DatesAreNull_DaysDifferenceFromDate()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.DaysDifferenceFromDate(null, null));
    }

    /// <summary>
    /// Verifies that the method returns zero when the initial date is after the final date in <see cref="DateQuery.DaysDifferenceFromDate"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnZero_When_InitialDateAfterFinalDate_DaysDifferenceFromDate()
    {
        var result = DateQuery.DaysDifferenceFromDate(DateTime.Today.AddDays(5), DateTime.Today);
        Assert.Equal(0, result);
    }

    /// <summary>
    /// Verifies that the correct difference in days is returned when valid dates are provided in <see cref="DateQuery.DaysDifferenceFromDate"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnCorrectDifference_When_DatesAreValid_DaysDifferenceFromDate()
    {
        var result = DateQuery.DaysDifferenceFromDate(DateTime.Today, DateTime.Today.AddDays(10));
        Assert.Equal(10, result);
    }

    /// <summary>
    /// Verifies that the correct number of days in a month is returned for a valid year and month in <see cref="DateQuery.DaysInMonth"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnCorrectDaysInMonth_When_ValidYearAndMonth()
    {
        int days = DateQuery.DaysInMonth(2024, 2);
        Assert.Equal(29, days); // Leap year
    }

    /// <summary>
    /// Verifies that an exception is thrown when the year or month is null in <see cref="DateQuery.DaysInMonth"/>.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_NullYearOrMonth_DaysInMonth()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.DaysInMonth(null, 2));
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.DaysInMonth(2024, null));
    }

    /// <summary>
    /// Verifies that the correct day is returned for a valid date in <see cref="DateQuery.GetDay"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnDay_When_ValidDate()
    {
        var day = DateQuery.GetDay(DateTime.Today);
        Assert.Equal(DateTime.Today.Day, day);
    }

    /// <summary>
    /// Verifies that an exception is thrown when the date is null in <see cref="DateQuery.GetDay"/>.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_NullDate_GetDay()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.GetDay(null));
    }

    /// <summary>
    /// Verifies that the correct month is returned for a valid date in <see cref="DateQuery.GetMonth"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnMonth_When_ValidDate()
    {
        var month = DateQuery.GetMonth(DateTime.Today);
        Assert.Equal(DateTime.Today.Month, month);
    }

    /// <summary>
    /// Verifies that the correct year is returned for a valid date in <see cref="DateQuery.GetYear"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnYear_When_ValidDate()
    {
        var year = DateQuery.GetYear(DateTime.Today);
        Assert.Equal(DateTime.Today.Year, year);
    }

    /// <summary>
    /// Verifies that the correct day of the year is returned for a valid date in <see cref="DateQuery.GetDayOfYear"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnDayOfYear_When_ValidDate()
    {
        var dayOfYear = DateQuery.GetDayOfYear(DateTime.Today);
        Assert.Equal(DateTime.Today.DayOfYear, dayOfYear);
    }

    /// <summary>
    /// Verifies that the day of the week is returned as a number between 1 and 7 for a valid date in <see cref="DateQuery.GetDayOfWeek"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnDayOfWeekAsNumber_When_ValidDate()
    {
        var dayOfWeek = DateQuery.GetDayOfWeek(DateTime.Today);
        Assert.InRange(dayOfWeek, 1, 7);
    }

    /// <summary>
    /// Verifies that the correct date for tomorrow is returned for a valid date in <see cref="DateQuery.Tomorrow"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnTomorrow_When_ValidDate()
    {
        var tomorrow = DateQuery.Tomorrow(DateTime.Today);
        Assert.Equal(DateTime.Today.AddDays(1).Date, tomorrow.Date);
    }

    /// <summary>
    /// Verifies that the correct date for yesterday is returned for a valid date in <see cref="DateQuery.Yesterday"/>.
    /// </summary>
    [Fact]
    public void Should_ReturnYesterday_When_ValidDate()
    {
        var yesterday = DateQuery.Yesterday(DateTime.Today);
        Assert.Equal(DateTime.Today.AddDays(-1).Date, yesterday.Date);
    }

    /// <summary>
    /// Verifies that an interval is correctly added to a date in <see cref="DateQuery.DateAdd"/>.
    /// </summary>
    /// <param name="interval">The interval to add (e.g., "yyyy", "m", "d").</param>
    /// <param name="number">The number of intervals to add.</param>
    [Theory]
    [InlineData("yyyy", 1)]
    [InlineData("m", 1)]
    [InlineData("d", 1)]
    public void Should_AddInterval_When_ValidDate(string interval, int number)
    {
        var date = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
        var result = DateQuery.DateAdd(interval, number, date);
        Assert.NotEqual(date, result);
    }

    /// <summary>
    /// Verifies that an invalid interval is handled correctly in <see cref="DateQuery.DateAdd"/>.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_InvalidIntervalInDateAdd()
    {
        var date = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Unspecified);
        Assert.Throws<ArgumentException>(() => DateQuery.DateAdd("invalid", 5, date));
    }

    /// <summary>
    /// Verifies that the correct number of a specific day of the week is counted between two dates in <see cref="DateQuery.GetNumDayOfWeekBetweenDates"/>.
    /// </summary>
    [Fact]
    public void Should_CountDayOfWeekCorrectly_GetNumDayOfWeekBetweenDates()
    {
        var start = new DateTime(2024, 4, 1, 0, 0, 0, DateTimeKind.Unspecified);
        var end = new DateTime(2024, 4, 30, 0, 0, 0, DateTimeKind.Unspecified);
        int count = DateQuery.GetNumDayOfWeekBetweenDates(2, start, end); // Monday
        Assert.True(count > 0);
    }

    /// <summary>
    /// Verifies that an exception is thrown when null values are provided in <see cref="DateQuery.GetNumDayOfWeekBetweenDates"/>.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_NullValues_GetNumDayOfWeekBetweenDates()
    {
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.GetNumDayOfWeekBetweenDates(null, DateTime.Today, DateTime.Today));
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.GetNumDayOfWeekBetweenDates(1, null, DateTime.Today));
        _ = Assert.Throws<ArgumentNullException>(() => DateQuery.GetNumDayOfWeekBetweenDates(1, DateTime.Today, null));
    }

    /// <summary>
    /// Verifies that leap years are correctly identified in <see cref="DateQuery.IsLeapYear"/>.
    /// </summary>
    /// <param name="year">The year to check.</param>
    /// <param name="expected">The expected result (true if leap year, false otherwise).</param>
    [Theory]
    [InlineData(2024, true)]
    [InlineData(2023, false)]
    public void Should_ValidateLeapYearCorrectly(int year, bool expected)
    {
        bool result = DateQuery.IsLeapYear(year);
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Verifies that an exception is thrown when the year is null in <see cref="DateQuery.IsLeapYear"/>.
    /// </summary>
    [Fact]
    public void Should_ThrowException_When_NullYear_IsLeapYear()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => DateQuery.IsLeapYear(null));
    }
}
