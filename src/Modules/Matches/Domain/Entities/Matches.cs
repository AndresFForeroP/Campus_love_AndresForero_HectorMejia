using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Matches.Domain.Entities
{
    public class Matches
    {
        public int Id_primer_usuario { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? primerusuario { get; set; }
        public int Id_segundo_usuario { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? segundoUsuario { get; set; }
    }
}