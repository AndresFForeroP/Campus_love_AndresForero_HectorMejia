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
                .AsNoTracking()
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
        public async Task AddAsynclike(Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities.Likes like)
        {
            try
            {
                var existeLike = await _context.Set<Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities.Likes>()
                    .AnyAsync(l => l.Id_usuario_darlike == like.Id_usuario_darlike && 
                                l.Id_usuario_recibirlike == like.Id_usuario_recibirlike);
                
                if (existeLike)
                {
                    return;
                }

                await _context.AddAsync(like);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar Like: {ex.Message}");
                throw;
            }
        }
        
        public async Task AddAsyncdislike(Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities.Dislikes dislike)
        {
            try
            {
                var existeDislike = await _context.Set<Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities.Dislikes>()
                    .AnyAsync(d => d.Id_usuario_dardislike == dislike.Id_usuario_dardislike && 
                                d.Id_usuario_recibirdislike == dislike.Id_usuario_recibirdislike);
                if (existeDislike)
                {
                    return;
                }
                await _context.AddAsync(dislike);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar Dislike: {ex.Message}");
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