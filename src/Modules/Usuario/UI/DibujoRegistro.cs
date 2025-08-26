using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class DibujoRegistro : IDibujoMenuRegistro
    {
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();
        public void InicioDibujoResgistroAsync()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("                         REGISTRO                               ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}