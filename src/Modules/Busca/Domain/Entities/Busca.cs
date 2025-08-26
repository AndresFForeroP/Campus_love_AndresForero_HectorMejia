using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Busca.Domain.Entities
{
    public class Busca
    {
        public int Id { get; set; }
        public string? busca { get; set; }
        public IEnumerable<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>? usuarios { get; set; }
    }
}