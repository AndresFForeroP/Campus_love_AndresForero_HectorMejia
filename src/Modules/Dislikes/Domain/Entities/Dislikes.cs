using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities
{
    public class Dislikes
    {
        public int Id_usuario_dardislike { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? usuario_dardislike { get; set; }
        public int Id_usuario_recibirdislike { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? usuario_recibirdislike { get; set; }
    }
}