using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI
{
    public class DibujosAgregarusuario : IDibujosAgregarUsuario
    {
        public string dibujopedirgenero()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[cyan]Seleccione un género:[/]")
                    .HighlightStyle(Style.Parse("white"))
                    .AddChoices(
                        "[blue]👨‍🎓 Hombre Cisgénero[/]",
                        "[teal]⚧ Hombre Intersexual[/]",
                        "[purple]👨‍🦱➡️⚧ Hombre Trans[/]",
                        "[pink1]👩‍🎓 Mujer Cisgénero[/]",
                        "[orchid]⚧ Mujer Intersexual[/]",
                        "[magenta]👩➡️⚧ Mujer Trans[/]",
                        "[yellow]🌈 Mas allá del binario[/]"
                    )
            );
        }
        public string dibujopedirorientacion()
        {
            return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[cyan]Seleccione su orientación sexual:[/]")
                .HighlightStyle(Style.Parse("white"))
                .AddChoices(
                    "[blue]❤️‍🔥 Heterosexual[/]",
                    "[red]🌈 Gay u homosexual[/]",
                    "[pink1]👩‍❤️‍👩 Lesbiana[/]",
                    "[purple]💜 Bisexual[/]",
                    "[grey]❄️ Asexual[/]",
                    "[teal]🤝 Demisexual[/]",
                    "[yellow]✨ Pansexual[/]",
                    "[magenta]🌟 Queer[/]",
                    "[orange1]🔍 Explorando[/]",
                    "[green]💚 Arromántico[/]",
                    "[violet]🌀 Omnisexual[/]",
                    "[white]❓ Otro[/]"
                )
            );
        }
        public string dibujopedirbusca()
        {
            return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[cyan]¿Qué estás buscando?[/]")
                .HighlightStyle(Style.Parse("white"))
                .AddChoices(
                    "[red]❤️ Relación[/]",
                    "[orange1]💞 Relación, pero no me cierro[/]",
                    "[yellow]🎉 Diversión, pero no me cierro[/]",
                    "[pink1]🔥 Diversión a corto plazo[/]",
                    "[blue]🤝 Hacer amigos[/]",
                    "[grey]🤔 Lo sigo pensando[/]"
                    )
            );
        }
        public List<string> dibujopedirintereses()
        {
            return AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title("[cyan]Seleccione sus intereses (puede elegir varios con [yellow]<space>[/]):[/]")
                    .NotRequired()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use ↑/↓ para navegar y <space> para seleccionar)[/]")
                    .InstructionsText(
                        "[grey](Presione [yellow]<space>[/] para marcar, [green]<enter>[/] para confirmar)[/]")
                    .AddChoices(
                        "[magenta]🎵 Música[/]",
                        "[green]⚽ Deportes[/]",
                        "[yellow]🎬 Cine[/]",
                        "[blue]✈️ Viajar[/]",
                        "[purple]📚 Leer[/]",
                        "[red]🍳 Cocina[/]",
                        "[teal]🎮 Videojuegos[/]",
                        "[orange1]🎨 Arte[/]",
                        "[green]🌿 Naturaleza[/]",
                        "[cyan]💻 Programación[/]",
                        "[pink1]📸 Fotografía[/]"
                    )
            );
        }
    }
}