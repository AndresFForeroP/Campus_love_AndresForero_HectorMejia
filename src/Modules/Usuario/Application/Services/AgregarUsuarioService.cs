using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.UI;
using Campus_love_AndresForero_HectorMejia.src.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Services
{
    public class AgregarUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private List<Domain.Entities.Usuario> _usuarios = new List<Domain.Entities.Usuario>();
        private DibujosAgregarusuario _dibujosAgregarusuario;
        public AgregarUsuarioService()
        {
            var context = DbContextFactory.Create();
            _usuarioRepository = new UsuarioRepository(context);

            _dibujosAgregarusuario = new DibujosAgregarusuario();
        }
        public async Task AgregarUsuario()
        {
            string nombre = PedirNombre();
            string usuario = PedirUsuario();
            string contraseña = PedirContraseña();
            int edad = PedirEdad();
            string carrera = PedirCarrera();
            string frase = PedirFrase();
            int genero = PedirGenero();
            int orientacion = PedirOrientacion();
            int busca = PedirBusca();
            List<int> intereses = PedirIntereses();
            var nuevoUsuario = new Domain.Entities.Usuario
            {
                nombre = nombre,
                usuario = usuario,
                contraseña = contraseña,
                edad = edad,
                carrera = carrera,
                frase = frase,
                Id_Genero = genero,
                Id_orientacion = orientacion,
                Id_busca = busca,
            };
            foreach (var item in intereses)
            {
                nuevoUsuario?.InteresesUsuario?.Add(new Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities.InteresesUsuario
                {
                    Id_interes = item,
                    Id_usuario = nuevoUsuario.Id
                });
            }


            await _usuarioRepository.AddAsync(nuevoUsuario ?? new Domain.Entities.Usuario());
        }
        private string PedirNombre()
        {
            string nombre = "";
            do
            {
                Console.Write("Ingrese su nombre: ");
                nombre = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(nombre));
            return nombre;
        }
        private string PedirUsuario()
        {
            string usuario = "";
            do
            {
                Console.Write("Ingrese su usuario: ");
                usuario = Console.ReadLine() ?? string.Empty;
                if (_usuarios.Any(u => (u.usuario ?? string.Empty).Equals(usuario, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Ese usuario ya existe, intente con otro.");
                    usuario = "";
                }
            } while (string.IsNullOrWhiteSpace(usuario));

            return usuario;
        }
        private string PedirContraseña()
        {
            string contraseña = "";
            do
            {
                Console.Write("Ingrese su contraseña: ");
                contraseña = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(contraseña));
            return contraseña;
        }
        private int PedirEdad()
        {
            int edad;
            do
            {
                Console.Write("Ingrese su edad: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(input, out edad))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            } while (edad <= 0);
            return edad;
        }
        private string PedirCarrera()
        {
            string carrera = "";
            do
            {
                Console.Write("Ingrese su carrera: ");
                carrera = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(carrera));
            return carrera;
        }
        private string PedirFrase()
        {
            string frase = "";
            do
            {
                Console.Write("Ingrese una frase que lo describa: ");
                frase = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrWhiteSpace(frase));
            return frase;
        }
        private int PedirGenero()
        {
            var genero = _dibujosAgregarusuario.dibujopedirgenero();
            switch (genero)
            {
                case "[blue]👨‍🎓 Hombre Cisgénero[/]":
                    return 1;
                case "[teal]⚧ Hombre Intersexual[/]":
                    return 2;
                case "[purple]👨‍🦱➡️⚧ Hombre Trans[/]":
                    return 3;
                case "[pink1]👩‍🎓 Mujer Cisgénero[/]":
                    return 4;
                case "[orchid]⚧ Mujer Intersexual[/]":
                    return 5;
                case "[magenta]👩➡️⚧ Mujer Trans[/]":
                    return 6;
                case "[yellow]🌈 Mas allá del binario[/]":
                    return 7;
            }
            return 0;
        }
        private int PedirOrientacion()
        {
            var orientacion = _dibujosAgregarusuario.dibujopedirorientacion();
            switch (orientacion)
            {
                case "[blue]❤️‍🔥 Heterosexual[/]":
                    return 1;
                case "[red]🌈 Gay u homosexual[/]":
                    return 2;
                case "[pink1]👩‍❤️‍👩 Lesbiana[/]":
                    return 3;
                case "[purple]💜 Bisexual[/]":
                    return 4;
                case "[grey]❄️ Asexual[/]":
                    return 5;
                case "[teal]🤝 Demisexual[/]":
                    return 6;
                case "[yellow]✨ Pansexual[/]":
                    return 7;
                case "[magenta]🌟 Queer[/]":
                    return 8;
                case "[orange1]🔍 Explorando[/]":
                    return 9;
                case "[green]💚 Arromántico[/]":
                    return 10;
                case "[violet]🌀 Omnisexual[/]":
                    return 11;
                case "[white]❓ Otro[/]":
                    return 12;
            }
            return 0;
        }
        private int PedirBusca()
        {
            var busca = _dibujosAgregarusuario.dibujopedirbusca();
            switch (busca)
            {
                case "[red]❤️ Relación[/]":
                    return 1;
                case "[orange1]💞 Relación, pero no me cierro[/]":
                    return 2;
                case "[yellow]🎉 Diversión, pero no me cierro[/]":
                    return 3;
                case "[pink1]🔥 Diversión a corto plazo[/]":
                    return 4;
                case "[blue]🤝 Hacer amigos[/]":
                    return 5;
                case "[grey]🤔 Lo sigo pensando[/]":
                    return 6;
            }
            return 0;
        }
        private List<int> PedirIntereses()
        {
            var intereses = _dibujosAgregarusuario.dibujopedirintereses(); 
            var interesesLimpios = new List<int>();

            foreach (var interes in intereses)
            {
                switch (interes)
                {
                    case "[magenta]🎵 Música[/]":
                        interesesLimpios.Add(1);
                        break;
                    case "[green]⚽ Deportes[/]":
                        interesesLimpios.Add(2);
                        break;
                    case "[yellow]🎬 Cine[/]":
                        interesesLimpios.Add(3);
                        break;
                    case "[blue]✈️ Viajar[/]":
                        interesesLimpios.Add(4);
                        break;
                    case "[purple]📚 Leer[/]":
                        interesesLimpios.Add(5);
                        break;
                    case "[red]🍳 Cocina[/]":
                        interesesLimpios.Add(6);
                        break;
                    case "[teal]🎮 Videojuegos[/]":
                        interesesLimpios.Add(7);
                        break;
                    case "[orange1]🎨 Arte[/]":
                        interesesLimpios.Add(8);
                        break;
                    case "[green]🌿 Naturaleza[/]":
                        interesesLimpios.Add(9);
                        break;
                    case "[cyan]💻 Programación[/]":
                        interesesLimpios.Add(10);
                        break;
                    case "[pink1]📸 Fotografía[/]":
                        interesesLimpios.Add(11);
                        break;
                }
            }
            return interesesLimpios;
        }

    }
}