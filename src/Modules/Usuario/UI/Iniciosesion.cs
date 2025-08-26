using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Shared.Helpers;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class Iniciosesion : IIniciosesion
    {
        private readonly DibujoInicioSesion dibujoInicioSesion = new DibujoInicioSesion();
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        private readonly DibujoMenus dibujoMenus = new DibujoMenus();
        private readonly UsuarioRepository _usuarioRepository;
        private List<Domain.Entities.Usuario> _usuarios = new List<Domain.Entities.Usuario>();
        public Iniciosesion()
        {
            var context = DbContextFactory.Create();
            _usuarioRepository = new UsuarioRepository(context);
            _usuarios = _usuarioRepository.GetAllAsync().Result.ToList();
        }
        public async Task IniciosesionAsync()
        {
            bool correcto = false;
            var usuario = AnsiConsole.Ask<string>("Ingrese su [green]nombre de usuario[/]:");
            var contrasena = AnsiConsole.Prompt(
                new TextPrompt<string>("[cyan]Ingrese su contraseña:[/]")
                .PromptStyle("cyan")
                .Secret()
            );
            AnsiConsole.MarkupLine("[yellow]Verificando sus credenciales...[/]");
            foreach (var item in _usuarios)
            {
                if (item.usuario == usuario && item.contraseña == HashSHA256(contrasena))
                {
                    correcto = true;
                    AnsiConsole.MarkupLine("[green]Credenciales correctas![/]");
                    var dibujoMenu = new MenuPrincipal();
                    dibujoMenuUsers.MostrarCargaInteractiva("Iniciando sesión, por favor espere...");
                    await Task.Delay(1000);
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[green]Inicio de sesión exitoso![/]");
                    AnsiConsole.MarkupLine($"[green]¡Bienvenido, {usuario}![/]");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    AnsiConsole.Clear();
                    var menuSesion = new MenusSesion(item.Id);
                    await menuSesion.OpcionesMenuSesionAsync();
                }
            }
            if (!correcto)
            {
                dibujoMenuUsers.MostrarError("Credenciales incorrectas. Intente de nuevo.");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                await IniciosesionAsync();
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