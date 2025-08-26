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
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar usuario: {ex.Message}");
                throw;
            }
        }
        public async Task AddAsyncIntereses(Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities.InteresesUsuario interesesUsuario)
        {

            try
            {
                await _context.AddAsync(interesesUsuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar InteresesUsuario: {ex.Message}");
                throw;
            }
        }
        public async Task DeleteAsync(Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario usuario)
        {
            try
            {
                _context.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                throw;
            }
        }
        public async Task UpdateAsync(Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities.Usuario usuario)
        {
            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}");
                throw;
            }
        }
        public async Task UpdateInteresesAsync(int userId, List<int> intereses)
        {
            var interesesUsuarioSet = _context.Set<Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities.InteresesUsuario>();
            var existentes = interesesUsuarioSet.Where(i => i.Id_usuario == userId);
            interesesUsuarioSet.RemoveRange(existentes);
            foreach (var interesId in intereses)
            {
                interesesUsuarioSet.Add(new Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities.InteresesUsuario
                {
                    Id_usuario = userId,
                    Id_interes = interesId
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}