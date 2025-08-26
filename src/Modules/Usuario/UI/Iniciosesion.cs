using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class Iniciosesion : IIniciosesion
    {
        private readonly DibujoInicioSesion dibujoInicioSesion = new DibujoInicioSesion();
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        private readonly DibujoMenus dibujoMenus = new DibujoMenus();
        public async Task IniciosesionAsync()
        {
            var usuario = AnsiConsole.Ask<string>("Ingrese su [green]nombre de usuario[/]:");
            var contrasena = AnsiConsole.Prompt(
                new TextPrompt<string>("[cyan]Ingrese su contraseña:[/]")
                .PromptStyle("cyan")
                .Secret()

            );
            AnsiConsole.MarkupLine("[yellow]Verificando sus credenciales...[/]");

            string usercorrecto = "admin";
            string passcorrecto = "1234";

            if (usuario == usercorrecto && contrasena == passcorrecto)
            {
                var dibujoMenu = new DibujoMenuPrincipal();
                dibujoMenuUsers.MostrarCargaInteractiva("Iniciando sesión, por favor espere...");
                await Task.Delay(1000);
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[green]Inicio de sesión exitoso![/]");
                AnsiConsole.MarkupLine($"[green]¡Bienvenido, {usuario}![/]");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                AnsiConsole.Clear();
                var menuSesion = new MenusSesion();
                await menuSesion.OpcionesMenuSesionAsync();


            }
            else
            {
                dibujoMenuUsers.MostrarError("Credenciales incorrectas. Intente de nuevo.");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                dibujoInicioSesion.IniciarDibujoAsync();
            }
        }
    }
}