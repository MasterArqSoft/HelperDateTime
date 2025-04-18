using HelperDateTime.Validations;

namespace HelperDateTimeTests.Validations;
/// <summary>
/// Contains unit tests for the HelperValidateDate class.
/// </summary>
public class HelperValidateDateTests
{
    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateDate"/> throws an <see cref="ArgumentNullException"/> when the date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_DateIsNull_ValidateDate()
    {
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateDate(null, "date"));
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateDate"/> does not throw an exception when the date is valid.
    /// </summary>
    [Fact]
    public void Should_NotThrow_When_DateIsValid_ValidateDate()
    {
        var date = DateTime.Now;
        var exception = Record.Exception(() => HelperValidateDate.ValidateDate(date, "date"));
        Assert.Null(exception);
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateNotNull{T}"/> throws an <see cref="ArgumentNullException"/> when a nullable struct value is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_NullStructValue_ValidateNotNull_Struct()
    {
        int? number = null;
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateNotNull(number, "number"));
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateNotNull{T}"/> does not throw an exception when a nullable struct value is valid.
    /// </summary>
    [Fact]
    public void Should_NotThrow_When_StructValueIsValid_ValidateNotNull_Struct()
    {
        int? number = 5;
        var exception = Record.Exception(() => HelperValidateDate.ValidateNotNull(number, "number"));
        Assert.Null(exception);
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateNotNull{T}"/> throws an <see cref="ArgumentNullException"/> when a reference type value is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_NullReferenceValue_ValidateNotNull_Class()
    {
        const string value = null!;
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateNotNull(value, "value"));
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateNotNull{T}"/> does not throw an exception when a reference type value is valid.
    /// </summary>
    [Fact]
    public void Should_NotThrow_When_ReferenceValueIsValid_ValidateNotNull_Class()
    {
        const string value = "HelperDateTime";
        var exception = Record.Exception(() => HelperValidateDate.ValidateNotNull(value, "value"));
        Assert.Null(exception);
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateString"/> throws an <see cref="ArgumentNullException"/> when the string is null, empty, or whitespace.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_StringIsNullOrEmpty_ValidateString()
    {
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateString(null!, "text"));
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateString("", "text"));
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateString("   ", "text"));
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateString"/> does not throw an exception when the string is valid.
    /// </summary>
    [Fact]
    public void Should_NotThrow_When_StringIsValid_ValidateString()
    {
        var exception = Record.Exception(() => HelperValidateDate.ValidateString("Valid String", "text"));
        Assert.Null(exception);
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidatePositive"/> throws an <see cref="ArgumentOutOfRangeException"/> when the value is null, zero, or negative.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentOutOfRangeException_When_ValueIsNullOrZeroOrNegative_ValidatePositive()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => HelperValidateDate.ValidatePositive(null, "number"));
        Assert.Throws<ArgumentOutOfRangeException>(() => HelperValidateDate.ValidatePositive(0, "number"));
        Assert.Throws<ArgumentOutOfRangeException>(() => HelperValidateDate.ValidatePositive(-5, "number"));
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidatePositive"/> does not throw an exception when the value is positive.
    /// </summary>
    [Fact]
    public void Should_NotThrow_When_ValueIsPositive_ValidatePositive()
    {
        var exception = Record.Exception(() => HelperValidateDate.ValidatePositive(10, "number"));
        Assert.Null(exception);
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateAndReturn{T, TResult}"/> returns the transformed value when the date is valid.
    /// </summary>
    [Fact]
    public void Should_ReturnTransformedValue_When_ValidDate_ValidateAndReturn()
    {
        var result = HelperValidateDate.ValidateAndReturn(DateTime.Now, d => d.Year, "date");
        Assert.True(result >= 2000); // Reasonable year
    }

    /// <summary>
    /// Tests that <see cref="HelperValidateDate.ValidateAndReturn{T, TResult}"/> throws an <see cref="ArgumentNullException"/> when the date is null.
    /// </summary>
    [Fact]
    public void Should_ThrowArgumentNullException_When_NullDateInValidateAndReturn()
    {
        Assert.Throws<ArgumentNullException>(() => HelperValidateDate.ValidateAndReturn(null, d => d.Year, "date"));
    }
}
