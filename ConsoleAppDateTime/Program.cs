// See https://aka.ms/new-console-template for more information
using HelperDateTime;

Console.WriteLine("======== Prueba funcionalidades de fechas ===========");
Console.WriteLine($" DateTime.UtcNow: {DateTime.UtcNow}");
Console.WriteLine($" DateTime.Now    : {DateTime.Now}");
Console.WriteLine($" DateTime.Today  : {DateTime.Today}");
Console.WriteLine();

DateTime fechaInicio = new(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
DateTime fechaFin = new(2024, 4, 10, 0, 0, 0, DateTimeKind.Local);
DateTime fechaPrueba = new(2024, 2, 29, 0, 0, 0, DateTimeKind.Local);

int? añoBisiesto = 2024;
int? añoInvalido = 0;
int? mes = 2;

/// <summary>
/// Executes a series of date-related functionality tests using the DateQuery helper class.
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

Console.WriteLine("\n================ Fin de pruebas ================\n");
/// <summary>
/// Executes a test function and handles any exceptions that occur during execution.
/// </summary>
/// <param func="prueba">A function that returns a string representing the test result.</param>
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
