// See https://aka.ms/new-console-template for more information
using HelperDateTime.Comparisons;
using HelperDateTime.Conversions;
using HelperDateTime.Queries;
using System.Globalization;
namespace ConsoleAppDateTime;
/// <summary>
/// Main program class for the ConsoleAppDateTime application.
/// Provides a menu-driven interface to test various date and time helper functions.
/// </summary>
public static class Program
{
    /// <summary>
    /// Entry point of the application. Displays a menu to the user and executes selected date/time operations.
    /// </summary>
    private static void Main()
    {
        Console.WriteLine("======== Bienvenido al Test de HelperDateTime ========\n");

        Console.Write("Ingrese una fecha base (formato yyyy-MM-dd): ");
        string? input = Console.ReadLine();
        if (!DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaBase))
        {
            Console.WriteLine("❌ Formato de fecha inválido. Terminando programa.");
            return;
        }

        while (true)
        {
            MostrarMenuPrincipal();
            Console.Write("\nSeleccione una opción: ");
            string? opcion = Console.ReadLine();

            if (opcion == "0")
            {
                break;
            }

            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine($"✅ ¿Año {fechaBase.Year} es bisiesto? {DateQuery.IsLeapYear(fechaBase.Year)}");
                        break;
                    case "2":
                        Console.WriteLine($"✅ Día: {DateQuery.GetDay(fechaBase)}, Mes: {DateQuery.GetMonth(fechaBase)}, Año: {DateQuery.GetYear(fechaBase)}");
                        break;
                    case "3":
                        int dias = LeerEnteroDesdeConsola("Ingrese el número de días a agregar: ");
                        Console.WriteLine($"✅ Fecha + {dias} días: {DateQuery.DateAdd("d", dias, fechaBase)}");
                        break;
                    case "4":
                        Console.WriteLine($"✅ Formato corto: {DateConversion.ToShortDateFormat(fechaBase)}");
                        Console.WriteLine($"✅ Formato medio: {DateConversion.ToMediumDateFormat(fechaBase)}");
                        Console.WriteLine($"✅ Formato largo: {DateConversion.ToLongDateFormat(fechaBase)}");
                        Console.WriteLine($"✅ Formato completo: {DateConversion.ToFullDateFormat(fechaBase)}");
                        break;
                    case "5":
                        Console.WriteLine($"✅ Día del año: {DateQuery.GetDayOfYear(fechaBase)}");
                        Console.WriteLine($"✅ Día de la semana: {DateQuery.GetDayOfWeek(fechaBase)}");
                        break;
                    case "6":
                        Console.WriteLine($"✅ Mañana de la fecha: {DateQuery.Tomorrow(fechaBase)}");
                        Console.WriteLine($"✅ Ayer de la fecha: {DateQuery.Yesterday(fechaBase)}");
                        break;
                    case "7":
                        Console.WriteLine($"✅ SystemDateTime: {DateTimeQuery.SystemDateTimeConvertUtcLocal("America/Bogota")}");
                        break;
                    case "8":
                        Console.WriteLine($"✅ CurrentDateConvertUtcLocal: {DateQuery.CurrentDateConvertUtcLocal("America/Bogota")}");
                        break;
                    case "9":
                        int? año = LeerEnteroDesdeConsola("Ingrese el año: ");
                        int? mes = LeerEnteroDesdeConsola("Ingrese el mes (1-12): ");
                        Console.WriteLine($"✅ Días en el mes: {DateQuery.DaysInMonth(año, mes)}");
                        break;
                    case "10":
                        Console.Write("Ingrese fecha inicio (yyyy-MM-dd): ");
                        string? fechaInicioInput = Console.ReadLine();
                        Console.Write("Ingrese fecha fin (yyyy-MM-dd): ");
                        string? fechaFinInput = Console.ReadLine();
                        if (DateTime.TryParseExact(fechaInicioInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaInicio) &&
                            DateTime.TryParseExact(fechaFinInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaFin))
                        {
                            Console.WriteLine($"✅ Diferencia de días: {DateQuery.DaysDifferenceFromDate(fechaInicio, fechaFin)}");
                        }
                        else
                        {
                            Console.WriteLine("❌ Formato de fechas inválido.");
                        }
                        break;
                    case "11":
                        Console.Write("Ingrese fecha inicio (yyyy-MM-dd): ");
                        string? fechaIniInput = Console.ReadLine();
                        Console.Write("Ingrese fecha fin (yyyy-MM-dd): ");
                        string? fechaFinalInput = Console.ReadLine();
                        Console.Write("Ingrese número de día de la semana (1=Domingo...7=Sábado): ");
                        int dayOfWeek = LeerEnteroDesdeConsola("");
                        if (DateTime.TryParseExact(fechaIniInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime iniDate) &&
                            DateTime.TryParseExact(fechaFinalInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                        {
                            Console.WriteLine($"✅ Número de días específicos: {DateQuery.GetNumDayOfWeekBetweenDates(dayOfWeek, iniDate, endDate)}");
                        }
                        else
                        {
                            Console.WriteLine("❌ Formato de fechas inválido.");
                        }
                        break;
                    case "12":
                        Console.Write("Ingrese fecha en formato corto (M/d/yyyy): ");
                        string? shortDateInput = Console.ReadLine();
                        Console.WriteLine($"✅ Fecha convertida: {DateConversion.StringToDate(shortDateInput!)}");
                        break;
                    case "13":
                        int anio = LeerEnteroDesdeConsola("Año: ");
                        int mes2 = LeerEnteroDesdeConsola("Mes: ");
                        int dia2 = LeerEnteroDesdeConsola("Día: ");
                        Console.WriteLine($"✅ Fecha formada: {DateConversion.FormatToDate(anio, mes2, dia2)}");
                        break;
                    case "14":
                        Console.WriteLine($"✅ Parte horaria (hora:minuto:segundo): {DateTimeQuery.GetTimePart(fechaBase)}");
                        break;
                    case "15":
                        int horas = LeerEnteroDesdeConsola("Ingrese el número de horas a agregar: ");
                        Console.WriteLine($"✅ Fecha + {horas} horas: {DateTimeQuery.DateTimeAdd("h", horas, fechaBase)}");
                        break;
                    case "16":
                        Console.WriteLine($"✅ Fecha y hora como cadena: {DateTimeConversions.DateTimeToString(fechaBase)}");
                        break;
                    case "17":
                        Console.Write("Ingrese fecha (yyyy-MM-dd): ");
                        string? fechaStr = Console.ReadLine();
                        Console.Write("Ingrese hora (HH:mm:ss): ");
                        string? horaStr = Console.ReadLine();
                        if (DateTime.TryParseExact(fechaStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datePart) &&
                            DateTime.TryParseExact(horaStr, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime timePart))
                        {
                            Console.WriteLine($"✅ Fecha y hora combinadas: {DateTimeConversions.ToDateTime(datePart, timePart)}");
                        }
                        else
                        {
                            Console.WriteLine("❌ Formato de fecha u hora inválido.");
                        }
                        break;
                    case "18":
                        Console.Write("Ingrese fecha y hora (ej: May 15, 2024 10:30:45): ");
                        string? fechaHoraStr = Console.ReadLine();
                        Console.WriteLine($"✅ Fecha convertida: {DateTimeConversions.StringToDateTime(fechaHoraStr!)}");
                        break;
                    case "19":
                        int anioF = LeerEnteroDesdeConsola("Año: ");
                        int mesF = LeerEnteroDesdeConsola("Mes: ");
                        int diaF = LeerEnteroDesdeConsola("Día: ");
                        int horaF = LeerEnteroDesdeConsola("Hora: ");
                        int minF = LeerEnteroDesdeConsola("Minuto: ");
                        int segF = LeerEnteroDesdeConsola("Segundo: ");
                        Console.WriteLine($"✅ Fecha formada: {DateTimeConversions.FormatToDateTime(anioF, mesF, diaF, horaF, minF, segF)}");
                        break;
                    case "20":
                        Console.Write("Ingrese una segunda fecha (yyyy-MM-dd): ");
                        string? fecha2Input = Console.ReadLine();
                        if (DateTime.TryParseExact(fecha2Input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaComparar))
                        {
                            Console.WriteLine($"✅ ¿{fechaBase} > {fechaComparar}? {DateComparison.IsDateAfter(fechaBase, fechaComparar)}");
                            Console.WriteLine($"✅ ¿{fechaBase} < {fechaComparar}? {DateComparison.IsDateBefore(fechaBase, fechaComparar)}");
                            Console.WriteLine($"✅ ¿{fechaBase} == {fechaComparar}? {DateComparison.IsDateEquals(fechaBase, fechaComparar)}");
                        }
                        else
                        {
                            Console.WriteLine("❌ Fecha inválida.");
                        }
                        break;
                    case "21":
                        Console.Write("Ingrese una segunda fecha y hora (yyyy-MM-dd HH:mm:ss): ");
                        string? dt2Input = Console.ReadLine();
                        if (DateTime.TryParseExact(dt2Input, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaHoraComparar))
                        {
                            Console.WriteLine($"✅ ¿{fechaBase} > {fechaHoraComparar}? {DateTimeComparison.DateTimeAfter(fechaBase, fechaHoraComparar)}");
                            Console.WriteLine($"✅ ¿{fechaBase} < {fechaHoraComparar}? {DateTimeComparison.DateTimeBefore(fechaBase, fechaHoraComparar)}");
                            Console.WriteLine($"✅ ¿{fechaBase} == {fechaHoraComparar}? {DateTimeComparison.DateTimeEquals(fechaBase, fechaHoraComparar)}");
                        }
                        else
                        {
                            Console.WriteLine("❌ Fecha y hora inválida.");
                        }
                        break;
                    default:
                        Console.WriteLine("❌ Opción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error ejecutando la opción: {ex.Message}");
            }
        }

        Console.WriteLine("\n======== Fin del programa ========\n");
    }

    /// <summary>
    /// Displays the main menu options to the user.
    /// </summary>
    private static void MostrarMenuPrincipal()
    {
        Console.WriteLine("\n--- Funciones de Fecha ---");
        Console.WriteLine(" 1. Verificar año bisiesto");
        Console.WriteLine(" 2. Obtener día, mes y año");
        Console.WriteLine(" 3. Sumar días");
        Console.WriteLine(" 4. Mostrar formatos de fecha");
        Console.WriteLine(" 5. Mostrar día del año y de la semana");
        Console.WriteLine(" 6. Obtener mañana y ayer");
        Console.WriteLine(" 7. Mostrar fecha/hora del sistema");
        Console.WriteLine(" 8. Fecha UTC local convertida");
        Console.WriteLine(" 9. Días en mes");
        Console.WriteLine("10. Diferencia de días");
        Console.WriteLine("11. Número de días de semana entre fechas");

        Console.WriteLine("\n--- Conversión Básica ---");
        Console.WriteLine("12. String a fecha");
        Console.WriteLine("13. Año, Mes, Día a fecha");

        Console.WriteLine("\n--- Fecha y Hora ---");
        Console.WriteLine("14. Parte horaria");
        Console.WriteLine("15. Sumar horas");
        Console.WriteLine("16. Formatear fecha/hora a texto");
        Console.WriteLine("17. Combinar fecha + hora");
        Console.WriteLine("18. String a fecha/hora completa");
        Console.WriteLine("19. Año, Mes, Día, Hora, Minuto, Segundo a fecha");

        Console.WriteLine("\n--- Comparaciones ---");
        Console.WriteLine("20. Comparar fechas");
        Console.WriteLine("21. Comparar fechas y horas");

        Console.WriteLine("\n0. Salir\n");
    }

    /// <summary>
    /// Reads an integer value from the console with validation.
    /// </summary>
    /// <param name="mensaje">The message to display to the user.</param>
    /// <returns>The integer value entered by the user.</returns>
    private static int LeerEnteroDesdeConsola(string mensaje)
    {
        string? entrada;
        while (true)
        {
            Console.Write(mensaje);
            entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int valor))
            {
                return valor;
            }

            Console.WriteLine("❌ Entrada inválida. Debe ser un número entero.");
        }
    }
}
