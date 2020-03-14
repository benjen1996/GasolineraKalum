using System;
using GasolineraKalum.Controllers;
using GasolineraKalum.Entities;
using GasolineraKalum.Menu;
using static GasolineraKalum.Util.Printer;


namespace GasolineraKalum
{
    class Program
    {
        static void Main(string[] args)
        {
            Beep();
            WriteTitle("Gasolinera Kalum");
            new MenuPrincipal().MostrarMenu();
            // string salida = "GasolineraKalum.Entities.Regular";

            //Console.WriteLine($"LastIndexOf {salida.Substring(salida.LastIndexOf(".") + 1)}");
            //Console.WriteLine($"Split {salida.Split(".")[2]}");

            // for (int i = salida.Length - 1; i >= 0; i--)
            // {



            //    if (salida.Substring(i, 1).Equals("."))
            //     {
            //       Console.WriteLine($"For/if {salida.Substring(i + 1, salida.Length - (i + 1))}");
            //       break;
            //    }

            // }

            PresionarEnter();

        }
    }
}
