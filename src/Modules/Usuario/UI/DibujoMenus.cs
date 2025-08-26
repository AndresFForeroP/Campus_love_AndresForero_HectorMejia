using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class DibujoMenus : IDibujoMenus
    {
        public String MenuInicioSesion()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("                       MENU INICIO DE SESIÓN                    "); 
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();

            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[cyan]Seleccione una opción:[/]")
                    .HighlightStyle(Style.Parse("cyan bold"))
                    .AddChoices(
                        " Encontrar el amor de tu vida",
                        " Matches",
                        " Cambiar mis datos",
                        "Eliminar mi cuenta",
                        " Cerrar sesión"
                    )
                    .UseConverter(op => op.Trim())
            );
        }
    }
}