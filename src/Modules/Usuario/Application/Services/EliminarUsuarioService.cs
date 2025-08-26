using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Campus_love_AndresForero_HectorMejia.src.Shared.Helpers;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Services
{
    public class EliminarUsuarioService : IEliminarusuarioRepository
    {
        private readonly UsuarioRepository _usuarioRepository;
        private List<Domain.Entities.Usuario> _usuarios = new List<Domain.Entities.Usuario>();

        public EliminarUsuarioService()
        {
            var context = DbContextFactory.Create();
            _usuarioRepository = new UsuarioRepository(context);
            _usuarios = _usuarioRepository.GetAllAsync().Result.ToList();
        }
        public async Task EliminarUsuario(int id)
        {
            AnsiConsole.MarkupLine("[yellow]Esta seguro de eliminar este usuario? [/]");
            var confirmacion = AnsiConsole.Confirm("[green]¿Desea continuar?[/]");
            if (!confirmacion)
            {
                AnsiConsole.MarkupLine("[red]Operación cancelada.[/]");
                var MenuSesion = new MenusSesion(id);
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                await MenuSesion.OpcionesMenuSesionAsync();
                
            }
            else
            {
                var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario != null)
                {
                    await _usuarioRepository.DeleteAsync(usuario);
                    _usuarios.Remove(usuario);
                    AnsiConsole.MarkupLine("[green]Usuario eliminado con éxito![/]");
                    var MenuPrincipal = new MenuPrincipal();
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    await MenuPrincipal.InicioAsync();
                }
            }
            
        }
    }
}