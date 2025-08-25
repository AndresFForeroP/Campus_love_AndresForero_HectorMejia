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
    public class DibujoMenuPrincipal : IDibujoMenuPrincipal
    {
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();

        public async Task InicioAsync()
        {

            Console.Clear();
            dibujoMenuUsers.MostrarBienvenida();
            dibujoMenuUsers.Inicio();
            var opcion = dibujoMenuUsers.Inicio();

            switch (opcion)
            {
                case " Iniciar Sesión":
                    var dibujoInicioSesion = new DibujoInicioSesion();
                    await dibujoInicioSesion.IniciarDibujoAsync();
                    break;
                case " Registrarse":
                    var dibujoRegistro = new DibujoRegistro();
                    await dibujoRegistro.InicioDibujoResgistroAsync();
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