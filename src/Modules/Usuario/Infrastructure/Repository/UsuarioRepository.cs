using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cafe_Colombiano.src.Shared.Context;
using Microsoft.EntityFrameworkCore;


namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository
{
    public class UsuarioRepository 
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}