// using System;
// using System.Collections.Generic;
// using System.Formats.Asn1;
// using System.Linq;
// using System.Threading.Tasks;
// using Cafe_Colombiano.src.Modules.Variedad.Application.Interfaces;
// using Cafe_Colombiano.src.Modules.Variedad.Application.Services;
// using Cafe_Colombiano.src.Modules.Variedad.Ui;
// using Microsoft.EntityFrameworkCore;
// using Spectre.Console;

// namespace Cafe_Colombiano.src.Modules.Variedad.Infrastructure.Repository
// {
//     public class VariedadRepository : IVariedadRepository
//     {
//         private DIbujoMenusFiltrar dibujoMenusFiltrar = new DIbujoMenusFiltrar();
//         internal readonly DbContext _context;

//         public VariedadRepository(DbContext context)
//         {
//             _context = context;
//         }


//         public async Task<IEnumerable<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad>> GetAllVariedadesAsync()
//         {
//             return await _context.Set<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad>()
//                 .Include(v => v.AltitudOptima)
//                 .Include(v => v.GrupoGenetico)
//                 .Include(v => v.Porte)
//                 .Include(v => v.TamanoGrano)
//                 .Include(v => v.PotencialRendimiento)
//                 .Include(v => v.CalidadGrano)
//                 .Include(v => v.InformacionAgronomica)
//                 .Include(v => v.VariedadesResistencia!)
//                     .ThenInclude(vr => vr.NivelResistencia)
//                 .Include(v => v.VariedadesResistencia!)
//                     .ThenInclude(vr => vr.TipoResistencia)
//                 .ToListAsync();
//         }
//         public async Task<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad?> GetVariedadByIdAsync(int id)
//         {
//             return await _context.Set<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad>()
//                 .Include(v => v.AltitudOptima)
//                 .Include(v => v.GrupoGenetico)
//                 .Include(v => v.Porte)
//                 .Include(v => v.TamanoGrano)
//                 .Include(v => v.PotencialRendimiento)
//                 .Include(v => v.CalidadGrano)
//                 .Include(v => v.InformacionAgronomica)
//                 .Include(v => v.VariedadesResistencia!)
//                     .ThenInclude(vr => vr.NivelResistencia)
//                 .Include(v => v.VariedadesResistencia!)
//                     .ThenInclude(vr => vr.TipoResistencia)
//                 .FirstOrDefaultAsync(v => v.id == id);
//         }
//         public async Task Add(Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad entity)
//         {
//             await _context.Set<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad>().AddAsync(entity);
//         }
//         public async Task Remove(Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad entity)
//         {
//             _context.Set<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad>().Remove(entity);
//             await _context.SaveChangesAsync();
//         }
//         public async Task Update(Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad entity)
//         {
//             _context.Set<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad>().Update(entity);
//             await _context.SaveChangesAsync();
//         }

//         public async Task SaveAsync()
//         {
//             await _context.SaveChangesAsync();
//         }
//         public IEnumerable<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad> FiltrarPorNombre(IEnumerable<Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad> Lista)
//         {
//             string nombre = dibujoMenusFiltrar.MenuNombre();
//             return Lista.Where(v => v.nombre_cientifico != null &&
//                                     v.nombre_cientifico.ToLower().Contains(nombre.ToLower()));
//         }
//     }
// }
// using System;

// namespace Cafe_Colombiano.src.Modules.VariedadResistencia.Domain.Entities
// {
//     public class VariedadResistencia
//     {
//         public int id_variedad { get; set; }
//         public int id_tipo_resistencia { get; set; }
//         public int id_nivel_resistencia { get; set; }
//         public Cafe_Colombiano.src.Modules.TipoResistencia.Domain.Entities.TipoResistencia? TipoResistencia { get; set; }
//         public Cafe_Colombiano.src.Modules.NivelResistencia.Domain.Entities.NivelResistencia? NivelResistencia { get; set; }
//         public Cafe_Colombiano.src.Modules.Variedad.Domain.Entities.Variedad? Variedad {get; set;}
//     }
// }