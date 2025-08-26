using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Genero.Domain.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string? genero { get; set; }
        public IEnumerable<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>? usuarios { get; set; }
    }
}