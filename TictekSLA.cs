public class TictekSLA
{
    public static void Main(String[] args)
    {
       Console.WriteLine("=================================================");
       Console.WriteLine("================= SLA - Ticket ==================");
       Console.WriteLine("=================================================");

       Console.WriteLine("Ingresa la fecha de creación (Dia/Mes/Año Hora:Minutos): ");
       DateTime fechaCreacion = DateTime.Parse(Console.ReadLine());

       Console.WriteLine("Ingresa la fecha de resolución (Dia/Mes/Año Hora:Minutos): ");
       DateTime fechaResolucion = DateTime.Parse(Console.ReadLine());

       double horasLaborales = CalcularHorasLaborales(fechaCreacion, fechaResolucion);
       Console.WriteLine($"\nHoras laborales transcurridas: {horasLaborales:F2}");

        if (horasLaborales <= 8)
       {
        Console.WriteLine("SLA: Cumplido");
       }
         else
       {
        Console.WriteLine($"SLA: Incumplido: {(horasLaborales - 8):F2} horas de más");
       }
    }

    public static double CalcularHorasLaborales(DateTime inicio, DateTime fin)
   {
       double totalHoras = 0;

       DateTime fechaActual = inicio.Date;

       while (fechaActual <= fin.Date)
       {
            // Excluir sábados y domingos
            if (fechaActual.DayOfWeek != DayOfWeek.Saturday &&
            fechaActual.DayOfWeek != DayOfWeek.Sunday)
            {
               DateTime inicioLaboral = fechaActual.AddHours(9); // 09:00
               DateTime finLaboral = fechaActual.AddHours(17);   // 17:00

               DateTime inicioReal = Max(inicio, inicioLaboral);
               DateTime finReal = Min(fin, finLaboral);

               if (inicioReal < finReal)
               {
                totalHoras += (finReal - inicioReal).TotalHours;
               }
            }

          fechaActual = fechaActual.AddDays(1);
        }
           return totalHoras;
    }

    public static DateTime Max(DateTime a, DateTime b)
      {
        return (a > b) ? a : b;
      }

    public static DateTime Min(DateTime a, DateTime b)
     {
        return (a < b) ? a : b;
     }   
}