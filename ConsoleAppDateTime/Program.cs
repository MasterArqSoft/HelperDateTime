// See https://aka.ms/new-console-template for more information
using HelperDateTime;

Console.WriteLine("======== Prueba funcionalidades de DateQuery ===========");
Console.WriteLine($" DateTime.UtcNow: {DateTime.UtcNow}");
Console.WriteLine($" DateTime.Now    : {DateTime.Now}");
Console.WriteLine($" DateTime.Today  : {DateTime.Today}");
Console.WriteLine();

DateTime fechaInicio = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
DateTime fechaFin = new(2024, 4, 10, 0, 0, 0, DateTimeKind.Unspecified);
DateTime fechaPrueba = new(2024, 2, 29, 0, 0, 0, DateTimeKind.Unspecified);

int? añoBisiesto = 2024;
int? añoInvalido = 0;
int? mes = 2;

/// <summary>
/// Executes various tests for the DateQuery class.
/// </summary>
Ejecutar(() => $"CurrentDateConvertUtcLocal: {DateQuery.CurrentDateConvertUtcLocal("America/Bogota")}");
Ejecutar(() => $"IsLeapYear({añoBisiesto}): {DateQuery.IsLeapYear(añoBisiesto)}");
Ejecutar(() => $"DaysInMonth({añoBisiesto}, {mes}): {DateQuery.DaysInMonth(añoBisiesto, mes)}");
Ejecutar(() => $"DaysDifferenceFromDate({fechaInicio}, {fechaFin}): {DateQuery.DaysDifferenceFromDate(fechaInicio, fechaFin)}");
Ejecutar(() => $"GetDay({fechaPrueba}): {DateQuery.GetDay(fechaPrueba)}");
Ejecutar(() => $"GetMonth({fechaPrueba}): {DateQuery.GetMonth(fechaPrueba)}");
Ejecutar(() => $"GetYear({fechaPrueba}): {DateQuery.GetYear(fechaPrueba)}");
Ejecutar(() => $"GetDayOfYear({fechaPrueba}): {DateQuery.GetDayOfYear(fechaPrueba)}");
Ejecutar(() => $"GetDayOfWeek({fechaPrueba}): {DateQuery.GetDayOfWeek(fechaPrueba)}");
Ejecutar(() => $"Tomorrow({fechaPrueba}): {DateQuery.Tomorrow(fechaPrueba)}");
Ejecutar(() => $"Yesterday({fechaPrueba}): {DateQuery.Yesterday(fechaPrueba)}");
Ejecutar(() => $"DateAdd(\"m\", 1, {fechaPrueba}): {DateQuery.DateAdd("m", 1, fechaPrueba)}");
Ejecutar(() => $"GetNumDayOfWeekBetweenDates(1, {fechaInicio}, {fechaFin}): {DateQuery.GetNumDayOfWeekBetweenDates(1, fechaInicio, fechaFin)}");

Ejecutar(() => $"IsLeapYear({añoInvalido}): {DateQuery.IsLeapYear(añoInvalido)}");

Console.WriteLine("\n================ Fin de pruebas DateQuery ================\n");

Console.WriteLine("======= Prueba de nuevas funciones de DateComparison =======\n");

DateTime? fecha1 = new DateTime(2024, 5, 15, 0, 0, 0, DateTimeKind.Local);
DateTime? fecha2 = new DateTime(2024, 5, 10, 0, 0, 0, DateTimeKind.Local);

/// <summary>
/// Executes various tests for the DateComparison class.
/// </summary>
Ejecutar(() => $"DateAfter({fecha1}, {fecha2}): {DateComparison.DateAfter(fecha1, fecha2)}");
Ejecutar(() => $"DateBefore({fecha2}, {fecha1}): {DateComparison.DateBefore(fecha2, fecha1)}");
Ejecutar(() => $"DateEquals({fecha1}, {fecha1}): {DateComparison.DateEquals(fecha1, fecha1)}");

Console.WriteLine("\n================ Fin de pruebas DateComparison ================\n");

Console.WriteLine("======= Prueba de nuevas funciones de DateConversion =======\n");
string cadenaFecha = "3/02/2005";
int? año = 2024, mess = 2, día = 30;

/// <summary>
/// Executes various tests for the DateConversion class.
/// </summary>
Ejecutar(() => $"ToShortDateFormat({fecha1}): {DateConversion.ToShortDateFormat(fecha1)}");
Ejecutar(() => $"ToMediumDateFormat({fecha1}): {DateConversion.ToMediumDateFormat(fecha1)}");
Ejecutar(() => $"ToLongDateFormat({fecha1}): {DateConversion.ToLongDateFormat(fecha1)}");
Ejecutar(() => $"ToFullDateFormat({fecha1}): {DateConversion.ToFullDateFormat(fecha1)}");

Ejecutar(() => $"StringToDate(\"{cadenaFecha}\"): {DateConversion.StringToDate(cadenaFecha)}");
Ejecutar(() => $"FormatToDate({año}, {mess}, {día}): {DateConversion.FormatToDate(año, mes, día)}");

Console.WriteLine("\n================ Fin de pruebas Date DateConversion ================\n");

Console.WriteLine("======== Prueba funcionalidades de fechas DateTimeQuery ===========");

/// <summary>
/// Executes various tests for the DateTimeQuery class.
/// </summary>
Console.WriteLine("✅ SystemDateTime(): " + DateTimeQuery.SystemDateTimeConvertUtcLocal("America/Bogota"));

DateTime? sampleDate = new DateTime(2024, 4, 11, 14, 35, 50, DateTimeKind.Unspecified);
Ejecutar(() => $"GetTimePart({sampleDate}): {DateTimeQuery.GetTimePart(sampleDate)}");
Ejecutar(() => $"DateTimeAdd(\"h\", 3, {sampleDate}): {DateTimeQuery.DateTimeAdd("h", 3, sampleDate)}");
Ejecutar(() => $"DateTimeAdd(\"d\", 5, {sampleDate}): {DateTimeQuery.DateTimeAdd("d", 5, sampleDate)}");
Ejecutar(() => $"DateTimeAdd(\"yyyy\", 2, {sampleDate}): {DateTimeQuery.DateTimeAdd("yyyy", 2, sampleDate)}");

Console.WriteLine("\n================ Fin de pruebas DateTimeQuery ================\n");

Console.WriteLine("======== Prueba funcionalidades de fechas DateTimeConversions ===========");

var date = new DateTime(2024, 5, 15, 0, 0, 0, DateTimeKind.Unspecified);
var time = new DateTime(1, 1, 1, 10, 30, 45, DateTimeKind.Unspecified);

/// <summary>
/// Executes various tests for the DateTimeConversions class.
/// </summary>
Ejecutar(() => $"ToDateTime({date}, {time}): {DateTimeConversions.ToDateTime(date, time)}");
Ejecutar(() => $"DateTimeToString({date}): {DateTimeConversions.DateTimeToString(date)}");
Ejecutar(() => $"StringToDateTime(\"May 15, 2024 10:30:45\"): {DateTimeConversions.StringToDateTime("May 15, 2024 10:30:45")}");
Ejecutar(() => $"FormatToDateTime(2024, 5, 15, 10, 30, 45): {DateTimeConversions.FormatToDateTime(2024, 5, 15, 10, 30, 45)}");

Console.WriteLine("\n================ Fin de pruebas DateTimeConversions ================\n");

Console.WriteLine("======== Prueba funcionalidades de fechas DateTimeComparison ===========");

DateTime? dt1 = new DateTime(2024, 4, 11, 14, 0, 0, DateTimeKind.Unspecified);
DateTime? dt2 = new DateTime(2024, 4, 11, 12, 30, 0, DateTimeKind.Unspecified);

/// <summary>
/// Executes various tests for the DateTimeComparison class.
/// </summary>
Ejecutar(() => $"DatetimeAfter({dt1}, {dt2}): {DateTimeComparison.DatetimeAfter(dt1, dt2)}");
Ejecutar(() => $"DatetimeBefore({dt2}, {dt1}): {DateTimeComparison.DatetimeBefore(dt2, dt1)}");
Ejecutar(() => $"DatetimeEquals({dt1}, {dt1}): {DateTimeComparison.DatetimeEquals(dt1, dt1)}");

Console.WriteLine("\n================ Fin de pruebas DateTimeComparison ================\n");

/// <summary>
/// Executes a test function and handles any exceptions that occur during execution.
/// </summary>
static void Ejecutar(Func<string> prueba)
{
    try
    {
        Console.WriteLine($"✅ {prueba.Invoke()}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}
