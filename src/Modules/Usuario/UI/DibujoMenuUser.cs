using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Spectre.Console;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class DibujoMenuUser : IDibujoMenuUser
    {
        public String Inicio()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("                       CAMPUS LOVE                              ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();

            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[cyan]Seleccione una opción:[/]")
                    .HighlightStyle(Style.Parse("cyan bold"))
                    .AddChoices(
                        " Iniciar Sesión",
                        " Registrarse",
                        " Salir"
                    )
                    .UseConverter(op => op.Trim())
            );
        }



        public void MostrarBienvenida()
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText("Bienvenido a Campus love")
                    .Centered()
                    .Color(Color.Red1));
            Console.ResetColor();
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }


        public void MostrarDespedida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("          Gracias por usar Campus Love. ¡Hasta luego!          ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
        public void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {mensaje}");
            Console.ResetColor();
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        public void MostrarCargaInteractiva(string mensaje)
        {
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots2)
                .SpinnerStyle(Style.Parse("green"))
                .Start(mensaje, ctx =>
                {
                    Thread.Sleep(1500);
                });
        }

    }
}