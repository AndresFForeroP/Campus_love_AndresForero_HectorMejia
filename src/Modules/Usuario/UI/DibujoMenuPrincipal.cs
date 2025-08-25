using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class DibujoMenuPrincipal() : IDibujoMenuPrincipal
    {

        public String Dibujoinicio()
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
                    .UseConverter (op => op.Trim())
            );
        }



        public void MostrarBienvenida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("               ¡Bienvenido a Campus Love!                      ");
            Console.WriteLine("----------------------------------------------------------------");
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

        public async Task IniciarAsync()
        {
            var opcion = Dibujoinicio();

            switch (opcion)
            {
                case " Iniciar Sesión":
                    var dibujoInicioSesion = new DibujoInicioSesion();
                    await dibujoInicioSesion.IniciarDibujoAsync();
                    break;
                case " Registrarse":
                    var dibujoRegistro = new DIbujoRegistro();
                    // await dibujoRegistro.IniciarDibujoAsync();
                    break;
                case " Salir":
                    MostrarDespedida();
                    Environment.Exit(0);
                    break;
                default:
                    MostrarError("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}