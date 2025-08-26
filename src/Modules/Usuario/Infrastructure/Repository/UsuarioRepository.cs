using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        internal readonly DbContext _context;
        public UsuarioRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>> GetAllAsync()
        {
            return await _context.Set<Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario>()
                .Include(u => u.genero!)
                .Include(u => u.InteresesUsuario!)
                    .ThenInclude(iu => iu.interes!)
                .Include(u => u.orientacion!)
                .Include(u => u.busca!)
                .Include(u => u.dislikedados!)
                .Include(u => u.dislikerecibidos!)
                .Include(u => u.likesdados!)
                .Include(u => u.likesrecibidos!)
                .Include(u => u.matches_1!)
                .Include(u => u.matches_2!)
                .ToListAsync();
        }
    }
}