using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Intereses.Domain.Entities
{
    public class Intereses
    {
        internal object nombre;

        public int Id { get; set; }
        public string? interes { get; set; }
        public string? descripcion { get; set; }
        public IEnumerable<Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities.InteresesUsuario>? InteresesUsuario { get; set; }
    }
}