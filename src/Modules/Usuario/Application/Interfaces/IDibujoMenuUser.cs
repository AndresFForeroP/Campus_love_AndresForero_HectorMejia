using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces
{
    public interface IDibujoMenuUser
    {
        string Inicio();
        void MostrarBienvenida();
        void MostrarDespedida();
        void MostrarError(string mensaje);

        void MostrarCargaInteractiva(string mensaje);
    }
}