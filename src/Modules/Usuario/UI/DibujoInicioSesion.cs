using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Cafe_Colombiano.src.Shared.Helpers;
using Spectre.Console;
using System.Security.Cryptography;
using System.Text;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI

{
    public class DibujoInicioSesion : IDibujoMenuSesion
    {
        public readonly UsuarioRepository repo = null!;
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
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
                .Secret()

            );
            AnsiConsole.MarkupLine("[yellow]Verificando credenciales...[/]");

            string usercorrecto = "admin";
            string passcorrecto = "1234";

            if (usuario == usercorrecto && contra == passcorrecto)
            {
                var dibujoMenu = new DibujoMenuPrincipal();
                dibujoMenuUsers.MostrarCargaInteractiva("Iniciando sesión, por favor espere...");
                await Task.Delay(1000);
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[green]Inicio de sesión exitoso![/]");
                AnsiConsole.MarkupLine($"[green]¡Bienvenido, {usuario}![/]");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                
                await dibujoMenu.InicioAsync();
            }
            else
            {
                dibujoMenuUsers.MostrarError("Credenciales incorrectas. Intente de nuevo.");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();

                await IniciarDibujoAsync();
            }
        }
        private string HashSHA256(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // Igual que en MySQL
        }
        
    }
}
