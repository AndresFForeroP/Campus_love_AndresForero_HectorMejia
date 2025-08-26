using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces
{
    public interface IMatchesUsuariosService
    {
        
        Task InicializarUsuarios();
        Task MostrarMatches(int id);
        Task MostrarMatchesConInput();
    }
}