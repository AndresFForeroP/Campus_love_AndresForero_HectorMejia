using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Services;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class MenuPrincipal : IMenuPrincipal
    {
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        private readonly IMenuRegistro menuRegistro = new MenuRegistro();
        private readonly IMenusSesion menusSesion = new MenusSesion();

        public async Task InicioAsync()
        {
            Console.Clear();
            dibujoMenuUsers.MostrarBienvenida();
            var opcion = dibujoMenuUsers.Inicio();

            switch (opcion)
            {
                case " Iniciar Sesión":
                    var InicioSesion = new Iniciosesion();
                    await InicioSesion.IniciosesionAsync();
                    break;
                case " Registrarse":
                    var dibujoRegistro = new DibujoRegistro();
                    dibujoRegistro.InicioDibujoResgistroAsync();
                    var AgregarUsuario = new AgregarUsuarioService();
                    await AgregarUsuario.AgregarUsuario();
                    break;
                case " Salir":
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