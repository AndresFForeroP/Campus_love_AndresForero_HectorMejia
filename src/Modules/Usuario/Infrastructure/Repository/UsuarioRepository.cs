using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
        public async Task AddAsync(Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario usuario)
        {

            try
            {
                Console.WriteLine($"Usuario agregado: {usuario.nombre} edad: {usuario.edad} carrera: {usuario.carrera} frase: {usuario.frase}");
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar usuario: {ex.Message}");
                throw;
            }
        }
    }
}