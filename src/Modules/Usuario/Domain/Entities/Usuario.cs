using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? nombre { get; set; } 
        public string? usuario { get; set; }
        public string? contraseña { get; set; }
        public int edad { get; set; }
        public int Id_Genero { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Genero.Domain.Entities.Genero? genero { get; set; }
        public string? carrera { get; set; }
        public string? frase { get; set; }
        public int Id_orientacion { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Orientacion.Domain.Entities.Orientacion? orientacion { get; set; }
        public int Id_busca { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Busca.Domain.Entities.Busca? busca { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities.Dislikes>? dislikedados { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities.Dislikes>? dislikerecibidos { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities.InteresesUsuario>? InteresesUsuario { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities.Likes>? likesdados { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities.Likes>? likesrecibidos { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Matches.Domain.Entities.Matches>? matches_1 { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Matches.Domain.Entities.Matches>? matches_2 { get; set; }
    }
}