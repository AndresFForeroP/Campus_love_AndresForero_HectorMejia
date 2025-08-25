using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class DIbujoRegistro
    {
        public async Task InicioDibujoResgistroAsync()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("                         REGISTRO                               ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();
            var usuarioRegister = AnsiConsole.Ask<string>("[cyan]Ingrese su nombre de usuario:[/]");
            var contraRegister = AnsiConsole.Prompt(
                new TextPrompt<string>("[cyan]Ingrese su contraseña:[/]")
                .PromptStyle("cyan")

            );
            AnsiConsole.MarkupLine("[yellow]Creando su cuenta...[/]");
            var dibujoMenu = new DibujoMenuPrincipal();
            dibujoMenu.MostrarCargaInteractiva("Registrando usuario, por favor espere...");
            await Task.Delay(1000);
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[green]¡Registro exitoso![/]");
            AnsiConsole.MarkupLine($"[green]¡Bienvenido, {usuarioRegister}![/]");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            dibujoMenu.Dibujoinicio();
        }
    }
}