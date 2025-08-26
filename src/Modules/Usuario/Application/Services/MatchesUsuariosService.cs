using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Spectre.Console;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Shared.Helpers;
using Microsoft.VisualBasic;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;


namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Services
{
    public class MatchesUsuariosService : IMatchesUsuariosService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly dynamic _context;
        private readonly DibujoMenuUser DibujoMenuUser = new DibujoMenuUser();
        private List<Domain.Entities.Usuario> _usuarios = new List<Domain.Entities.Usuario>();

        public MatchesUsuariosService(IUsuarioRepository usuarioRepository)
        {
            _context = DbContextFactory.Create();
            _usuarioRepository = new UsuarioRepository(_context);
            _usuarios = _usuarioRepository.GetAllAsync().Result.ToList();
        }

        public async Task MostrarMatches(int id)
        {
            await Task.Run(() =>
            {
                var Matches = new List<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>();
                foreach (var item in _usuarios)
                {
                    if (item.matches_1 != null && item.matches_1.Any(m => m.Id_segundo_usuario == id) ||
                        item.matches_2 != null && item.matches_2.Any(m => m.Id_primer_usuario == id))
                    {
                        Matches.Add(item);
                    }
                }
                foreach (var item in Matches)
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
                        .Header("💖 Match Encontrado 💖", Justify.Center)
                        .BorderColor(Color.HotPink);
                    AnsiConsole.Write(panel);
                    AnsiConsole.MarkupLine("[bold yellow]Presione cualquier tecla para ver siguiente match[/]");
                }
                if (Matches.Count == 0)
                {
                    var panel = new Panel("[bold red]💔 No tienes matches aún 💔[/]")
                        .Border(BoxBorder.Double)
                        .BorderColor(Color.Red)
                        .Header("MATCH SYSTEM", Justify.Center);

                    AnsiConsole.Write(panel);
                }
            });
        }

        public Task MostrarMatchesConInput()
        {
            throw new NotImplementedException();
        }
    }
}