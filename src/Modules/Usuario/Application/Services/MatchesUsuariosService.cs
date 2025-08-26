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
        private readonly DibujoMenuUser DibujoMenuUser = new DibujoMenuUser();
        private List<Domain.Entities.Usuario> _usuarios = new List<Domain.Entities.Usuario>();

        public MatchesUsuariosService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task InicializarUsuarios()
        {
            try
            {
                _usuarios = (await _usuarioRepository.GetAllAsync()).ToList();
                AnsiConsole.MarkupLine($"[green]✅ Se cargaron {_usuarios.Count} usuarios correctamente[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]❌ Error al cargar usuarios: {ex.Message}[/]");
                _usuarios = new List<Domain.Entities.Usuario>();
            }
        }

        public async Task MostrarMatches(int id)
        {
            try
            {
                // Header principal
                var rule = new Rule("[bold yellow]💕 SISTEMA DE MATCHES - CAMPUS LOVE 💕[/]");
                rule.Justify(Justify.Center);
                AnsiConsole.Write(rule);
                AnsiConsole.WriteLine();

                // Debug: Mostrar estado inicial
                AnsiConsole.MarkupLine($"[blue]🔍 Iniciando búsqueda de matches...[/]");
                
                // Asegurarse de que los usuarios estén cargados
                if (!_usuarios.Any())
                {
                    AnsiConsole.MarkupLine("[yellow]⚠️ Cargando usuarios...[/]");
                    await InicializarUsuarios();
                }

                // Verificar si se cargaron usuarios
                if (!_usuarios.Any())
                {
                    AnsiConsole.MarkupLine("[red]❌ No se pudieron cargar usuarios de la base de datos.[/]");
                    AnsiConsole.MarkupLine("[yellow]💡 Verifica la conexión a la base de datos.[/]");
                    return;
                }

                AnsiConsole.MarkupLine($"[green]📊 Total de usuarios en el sistema: {_usuarios.Count}[/]");
                AnsiConsole.WriteLine();

                // Mostrar información de usuarios para debug
                AnsiConsole.MarkupLine("[dim]🔍 Información de usuarios:[/]");
                foreach (var u in _usuarios.Take(3)) // Solo mostrar los primeros 3 para debug
                {
                    AnsiConsole.MarkupLine($"[dim]- ID: {u.Id}, Nombre: {u.nombre}, Género: {u.Id_Genero}, Busca: {u.Id_busca}[/]");
                }
                if (_usuarios.Count > 3)
                {
                    AnsiConsole.MarkupLine($"[dim]... y {_usuarios.Count - 3} usuarios más[/]");
                }
                AnsiConsole.WriteLine();

                // Contadores
                int totalMatches = 0;
                int usuariosConMatches = 0;
                int usuariosProcesados = 0;

                // Recorrer todos los usuarios con foreach
                foreach (var usuario in _usuarios)
                {
                    usuariosProcesados++;
                    
                    // Debug: Mostrar progreso cada 5 usuarios
                    if (usuariosProcesados % 5 == 0 || usuariosProcesados == _usuarios.Count)
                    {
                        AnsiConsole.MarkupLine($"[dim]🔄 Procesando usuario {usuariosProcesados}/{_usuarios.Count}[/]");
                    }

                    // Verificar datos del usuario
                    if (usuario.Id_busca == 0 || usuario.Id_Genero == 0)
                    {
                        AnsiConsole.MarkupLine($"[yellow]⚠️ Usuario {usuario.nombre} (ID: {usuario.Id}) tiene datos incompletos (Género: {usuario.Id_Genero}, Busca: {usuario.Id_busca})[/]");
                        continue;
                    }

                    // Buscar matches para el usuario actual
                    var candidatos = _usuarios.Where(item => item.Id != usuario.Id).ToList();
                    AnsiConsole.MarkupLine($"[dim]👤 {usuario.nombre}: evaluando {candidatos.Count} candidatos...[/]");

                    var matches = candidatos.Where(item =>
                    {
                        // Debug: Verificar cada condición
                        bool noDisliked = !(usuario.dislikedados?.Any(d => d.Id_usuario_dislike == item.Id) ?? false);
                        bool noLiked = !(usuario.likesdados?.Any(l => l.Id_usuario_like == item.Id) ?? false);
                        bool orientacionCompatible1 = usuario.Id_busca == item.Id_Genero;
                        bool orientacionCompatible2 = item.Id_busca == usuario.Id_Genero;

                        bool esMatch = noDisliked && noLiked && orientacionCompatible1 && orientacionCompatible2;

                        // Debug para el primer candidato
                        if (item == candidatos.FirstOrDefault())
                        {
                            AnsiConsole.MarkupLine($"[dim]  🔍 Evaluando {item.nombre}: NoDislike={noDisliked}, NoLike={noLiked}, Orient1={orientacionCompatible1}({usuario.Id_busca}=={item.Id_Genero}), Orient2={orientacionCompatible2}({item.Id_busca}=={usuario.Id_Genero}) -> Match={esMatch}[/]");
                        }

                        return esMatch;
                    }).ToList();

                    AnsiConsole.MarkupLine($"[dim]  ✅ {usuario.nombre} tiene {matches.Count} matches[/]");

                    // Solo mostrar si tiene matches
                    if (matches.Any())
                    {
                        usuariosConMatches++;
                        totalMatches += matches.Count;

                        // Panel del usuario
                        var userPanel = new Panel($"[bold cyan]{usuario.nombre}[/] ([dim]ID: {usuario.Id}[/])\n" +
                                                $"[yellow]Edad:[/] {usuario.edad} años\n" +
                                                $"[green]Carrera:[/] {usuario.carrera ?? "No especificada"}\n" +
                                                $"[purple]Género:[/] {usuario.Id_Genero} | [orange3]Busca:[/] {usuario.Id_busca}\n" +
                                                $"[blue]Frase:[/] [italic]{usuario.frase ?? "Sin frase"}[/]")
                        {
                            Header = new PanelHeader($"👤 Usuario: {usuario.nombre}"),
                            Border = BoxBorder.Rounded,
                            BorderStyle = Style.Parse("cyan")
                        };

                        AnsiConsole.Write(userPanel);

                        // Tabla de matches
                        var table = new Table();
                        table.Border = TableBorder.Heavy;
                        table.BorderStyle = Style.Parse("magenta");
                        table.Title = new TableTitle($"[bold green]💖 {matches.Count} Matches Encontrados[/]");
                        
                        table.AddColumn(new TableColumn("[yellow]👤 Nombre[/]").Centered());
                        table.AddColumn(new TableColumn("[blue]💬 Frase[/]").LeftAligned());
                        table.AddColumn(new TableColumn("[green]🎓 Carrera[/]").LeftAligned());
                        table.AddColumn(new TableColumn("[purple]🎂 Edad[/]").Centered());
                        table.AddColumn(new TableColumn("[orange3]🔄 G/B[/]").Centered());
                        table.AddColumn(new TableColumn("[cyan]🎯 Intereses[/]").LeftAligned());

                        foreach (var match in matches)
                        {
                            string intereses = string.Join(", ",
                                match.InteresesUsuario?.Select(i => i.interes?.nombre) ?? new List<string>());

                            if (string.IsNullOrEmpty(intereses))
                                intereses = "[dim italic]Sin intereses[/]";

                            table.AddRow(
                                $"[bold]{match.nombre ?? "N/A"}[/]",
                                match.frase ?? "[dim]Sin frase[/]",
                                match.carrera ?? "[dim]Sin carrera[/]",
                                $"[bold]{match.edad}[/] años",
                                $"{match.Id_Genero}/{match.Id_busca}",
                                intereses
                            );
                        }

                        AnsiConsole.Write(table);

                        // Separador elegante entre usuarios
                        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("dim")));
                        AnsiConsole.WriteLine();
                    }
                }

                // Resumen final
                AnsiConsole.WriteLine();
                var summaryPanel = new Panel(
                    $"[green]✅ Usuarios procesados:[/] [bold]{usuariosProcesados}[/]\n" +
                    $"[yellow]👥 Usuarios con matches:[/] [bold]{usuariosConMatches}[/]\n" +
                    $"[blue]📊 Total de matches:[/] [bold]{totalMatches}[/]\n" +
                    $"[purple]🗃️ Total de usuarios en BD:[/] [bold]{_usuarios.Count}[/]")
                {
                    Header = new PanelHeader("📈 Resumen Final"),
                    Border = BoxBorder.Double,
                    BorderStyle = Style.Parse("green")
                };

                AnsiConsole.Write(summaryPanel);

                // Mensaje final
                if (totalMatches == 0)
                {
                    var noMatchesPanel = new Panel("[red]❌ No se encontraron matches en el sistema.[/]\n" +
                                                  $"[yellow]💡 Posibles causas:[/]\n" +
                                                  $"[dim]- Incompatibilidades de orientación sexual[/]\n" +
                                                  $"[dim]- Todos los usuarios ya han interactuado[/]\n" +
                                                  $"[dim]- Datos incompletos en los perfiles[/]")
                    {
                        Header = new PanelHeader("💔 Diagnóstico"),
                        Border = BoxBorder.Rounded,
                        BorderStyle = Style.Parse("red")
                    };
                    AnsiConsole.Write(noMatchesPanel);
                }

            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]❌ Error en MostrarMatches: {ex.Message}[/]");
                AnsiConsole.MarkupLine($"[red]📍 Stack trace: {ex.StackTrace}[/]");
            }
        }

        public Task MostrarMatchesConInput()
        {
            throw new NotImplementedException();
        }
    }
}