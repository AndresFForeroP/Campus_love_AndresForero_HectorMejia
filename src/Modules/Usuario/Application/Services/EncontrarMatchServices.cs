using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Shared.Helpers;
using Spectre.Console;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Services
{
    public class EncontrarMatchServices : IEncontrarMatch
    {
        private readonly UsuarioRepository _usuarioRepository;
        private List<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario> _usuarios;
        private readonly dynamic _context;

        public EncontrarMatchServices()
        {
            _context = DbContextFactory.Create();
            _usuarioRepository = new UsuarioRepository(_context);
            _usuarios = _usuarioRepository.GetAllAsync().Result.ToList();
        }
        public async Task EncontrarMatch(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                var panel = new Panel("[bold red]❌ Usuario no encontrado. Operación cancelada. ❌[/]")
                    .Border(BoxBorder.Double)
                    .BorderColor(Color.Red)
                    .Header("MATCH SYSTEM", Justify.Center);

                AnsiConsole.Write(panel);
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            var posiblesMatches = new List<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>();
            foreach (var item in _usuarios)
            {
                if (item.Id != usuario.Id
                    && !(usuario.dislikedados?.Any(d => d.Id_usuario_recibirdislike == item.Id) ?? false)
                    && !(usuario.likesdados?.Any(l => l.Id_usuario_recibirlike == item.Id) ?? false))
                {
                    posiblesMatches.Add(item);
                }
            }
            if (posiblesMatches.Count == 0)
            {
                var panel = new Panel("[bold red]💔 No se encontraron posibles matches 💔[/]")
                    .Border(BoxBorder.Double)
                    .BorderColor(Color.Red)
                    .Header("MATCH SYSTEM", Justify.Center);

                AnsiConsole.Write(panel);
            }
            else
            {
                foreach (var item in posiblesMatches)
                {
                    var intereses = string.Join(", ", item.InteresesUsuario?.Select(i => i.interes?.interes) ?? new List<string>());
                    var panel = new Panel(
                        $"[bold yellow]{item.nombre}[/]\n" +
                        $"[blue]Usuario:[/] {item.usuario}\n" +
                        $"[green]Edad:[/] {item.edad}\n" +
                        $"[purple]Carrera:[/] {item.carrera}\n" +
                        $"[italic cyan]Frase:[/] \"{item.frase}\"\n" +
                        $"[bold magenta]Intereses:[/] {intereses}" +
                        $"\n[bold red]❤️‍🔥 Orientación:[/] {item.orientacion?.orientacion} | [bold blue]💙 Busca:[/] {item.busca?.busca}"
                    )
                    .Border(BoxBorder.Rounded)
                    .Header("💖 Posible Match Encontrado 💖", Justify.Center)
                    .BorderColor(Color.HotPink);
                    AnsiConsole.Write(panel);
                    AnsiConsole.MarkupLine("[bold yellow]¿Quieres hacerle match?[/]");
                    var opcion = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Elige una opción:")
                            .AddChoices(new[] { "💖  Sí", "❌  No" }));
                    Console.Clear();
                    if (opcion == "💖  Sí")
                    {
                        var nuevoLike = new Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities.Likes
                        {
                            Id_usuario_darlike = usuario.Id,
                            Id_usuario_recibirlike = item.Id
                        };
                        await _usuarioRepository.AddAsynclike(nuevoLike);
                    }
                    else
                    {
                        var nuevoDislike = new Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities.Dislikes
                        {
                            Id_usuario_dardislike = usuario.Id,
                            Id_usuario_recibirdislike = item.Id
                        };
                        await _usuarioRepository.AddAsyncdislike(nuevoDislike);
                    }

                }
            }
            var menuSesion = new MenusSesion(id);
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            await menuSesion.OpcionesMenuSesionAsync();
        }
    }
}