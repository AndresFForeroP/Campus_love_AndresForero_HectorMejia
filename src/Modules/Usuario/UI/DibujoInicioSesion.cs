using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI

{
    public class DibujoInicioSesion
    {
        public async Task IniciarDibujoAsync()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("                       INICIO DE SESIÓN                         ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();

            var usuario = AnsiConsole.Ask<string>("[cyan]Ingrese su nombre de usuario:[/]");
            var contra = AnsiConsole.Prompt(
                new TextPrompt<string>("[cyan]Ingrese su contraseña:[/]")
                .PromptStyle("cyan")

            );
            AnsiConsole.MarkupLine("[yellow]Verificando credenciales...[/]");
            var dibujoMenu = new DibujoMenuPrincipal();
            dibujoMenu.MostrarCargaInteractiva("Iniciando sesión, por favor espere...");
            await Task.Delay(1000);
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[green]Inicio de sesión exitoso![/]");
            AnsiConsole.MarkupLine($"[green]¡Bienvenido, {usuario}![/]");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            dibujoMenu.Dibujoinicio();
            

        }
    }
}