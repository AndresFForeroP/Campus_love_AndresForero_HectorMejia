using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class MenuRegistro : IMenuRegistro
    {
        private readonly DibujoMenuUser dibujoMenuUsers = new DibujoMenuUser();

        public async Task FuncionRegistroAsync()
        {
            var usuarioRegister = AnsiConsole.Ask<string>("[cyan]Ingrese su nombre de usuario:[/]");
            var contraRegister = AnsiConsole.Prompt(
                new TextPrompt<string>("[cyan]Ingrese su contraseña:[/]")
                .PromptStyle("cyan")
                .Secret()

            );
            AnsiConsole.MarkupLine("[yellow]Creando su cuenta...[/]");
            var dibujoMenu = new MenuPrincipal();
            dibujoMenuUsers.MostrarCargaInteractiva("Registrando usuario, por favor espere...");
            await Task.Delay(1000);
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[green]¡Registro exitoso![/]");

            
            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.AddColumn(new TableColumn("[cyan]Información[/]").Centered());
            table.AddColumn(new TableColumn("[cyan]Detalles[/]").Centered());
            table.AddRow($"[green]Usuario:[/] ", usuarioRegister);
            table.AddRow($"[green]Contraseña:[/] ", new string('*', contraRegister.Length));
            table.AddRow($"[green]Fecha de Registro:[/] ", DateTime.Now.ToString("g"));
            table.AddRow($"[green]Estado:[/] ", "[green]Activo[/]");

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine($"[green]¡Bienvenido, {usuarioRegister}![/]");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            await dibujoMenu.InicioAsync();
        }
    }
}