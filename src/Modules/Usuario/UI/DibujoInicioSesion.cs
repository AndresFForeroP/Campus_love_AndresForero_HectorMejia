using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Spectre.Console;
using System.Security.Cryptography;
using System.Text;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI

{
    public class DibujoInicioSesion : IDibujoInicioSesion
    {
        public readonly UsuarioRepository repo = null!;
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        private readonly DibujoMenus dibujoMenus = new DibujoMenus();
        public void IniciarDibujoAsync()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("                       INICIO DE SESIÓN                         ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();

        } 
    }
}
