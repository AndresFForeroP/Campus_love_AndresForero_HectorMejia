using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Services;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class MenusSesion : IMenusSesion
    {

        private readonly DibujoMenus dibujoMenus = new DibujoMenus();
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        private readonly MatchesUsuariosService matchesUsuariosService = new MatchesUsuariosService(new UsuarioRepository(new Microsoft.EntityFrameworkCore.DbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Microsoft.EntityFrameworkCore.DbContext>())));
        private int id;

        public MenusSesion(int id)
        {
            this.id = id;
        }

        public async Task OpcionesMenuSesionAsync()
        {
            Console.Clear();
            var opcion2 = dibujoMenus.MenuInicioSesion();

            switch (opcion2)
            {
                case " Encontrar el amor de tu vida":
                    var buscarParejaService = new EncontrarMatchServices();
                    await buscarParejaService.EncontrarMatch(id);
                    break;
                case " Matches":
                    await matchesUsuariosService.MostrarMatches(id);
                    break;
                case " Cambiar mis datos":
                    var actualizarUsuarioServices = new ActualizarUsuarioServices();
                    await actualizarUsuarioServices.ActualizarUsuario(id);
                    break;
                case "Eliminar mi cuenta":
                    var eliminarUsuarioService = new EliminarUsuarioService();
                    await eliminarUsuarioService.EliminarUsuario(id);
                    break;
                case " Cerrar sesión":
                    dibujoMenuUsers.MostrarDespedida();
                    Environment.Exit(0);
                    break;
                default:
                    dibujoMenuUsers.MostrarError("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}