// See https://aka.ms/new-console-template for more information
using HelperDateTime;

Console.WriteLine("======== Prueba funcionalidades de fechas ===========");
Console.WriteLine($" DateTime.UtcNow: {DateTime.UtcNow} - DateTime.Now {DateTime.Now} - DateTime.Today:  {DateTime.Today}");
try
{
    Console.WriteLine(value: $"El Resultado Current Date: {DateQuery.CurrentDateConvertUtcLocal("America/Bogota")}");
    Console.WriteLine(value: $"El Resultado si el año es bisiesto: {DateQuery.IsLeapYear(0)}");
}
catch (Exception ex)
{

    Console.WriteLine(value: $"Error {ex.Message}");
}