using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class MenuPrincipal : IMenuPrincipal
    {
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        private readonly IMenuRegistro menuRegistro = new MenuRegistro();

        public Task InicioAsync()
        {
            Console.Clear();
            dibujoMenuUsers.MostrarBienvenida();
            var opcion = dibujoMenuUsers.Inicio();

            switch (opcion)
            {
                case " Iniciar Sesión":
                    var dibujoInicioSesion = new DibujoInicioSesion();
                    dibujoInicioSesion.IniciarDibujoAsync();
                    break;
                case " Registrarse":
                    var dibujoRegistro = new DibujoRegistro();
                    dibujoRegistro.InicioDibujoResgistroAsync();
                    break;
                case " Salir":
                    dibujoMenuUsers.MostrarDespedida();
                    Environment.Exit(0);
                    break;
                default:
                    dibujoMenuUsers.MostrarError("Opción no válida. Intente de nuevo.");
                    break;
            }

            return Task.CompletedTask;
        }

    }
}