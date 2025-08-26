using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Orientacion.Domain.Entities
{
    public class Orientacion
    {
        public int Id { get; set; }
        public string? orientacion { get; set; }
        public ICollection<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>? usuarios { get; set; }

    }
}