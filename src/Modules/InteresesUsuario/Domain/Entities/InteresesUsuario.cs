using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities
{
    public class InteresesUsuario
    {
        public int Id_usuario { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? usuario { get; set; }
        public int Id_interes { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Intereses.Domain.Entities.Intereses? interes { get; set; }
    }
}