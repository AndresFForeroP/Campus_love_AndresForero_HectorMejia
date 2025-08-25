using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Spectre.Console;


internal class Program
{
    public static async Task Main(string[] args)
    {
        DibujoMenuPrincipal dibujoMenu = new DibujoMenuPrincipal();
        dibujoMenu.MostrarBienvenida();
        dibujoMenu.Dibujoinicio();
        await dibujoMenu.IniciarAsync();
    }
}