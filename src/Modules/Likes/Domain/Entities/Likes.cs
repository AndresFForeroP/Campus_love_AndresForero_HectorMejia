using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities
{
    public class Likes
    {
        public int Id_usuario_darlike { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? usuario_darlike { get; set; }
        public int Id_usuario_recibirlike { get; set; }
        public Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario? usuario_recibirlike { get; set; }
    }
}