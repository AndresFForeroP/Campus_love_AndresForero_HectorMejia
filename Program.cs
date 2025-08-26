using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;


internal class Program
{
    public static async Task Main(string[] args)
    {
        var dibujoMenu = new DibujoMenuPrincipal();
        await dibujoMenu.InicioAsync();
    }
}