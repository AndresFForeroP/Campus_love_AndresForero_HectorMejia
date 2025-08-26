using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
            public DbSet<Modules.Usuario.Domain.Entities.Usuario> Usuario { get; set; }
            public DbSet<Modules.Genero.Domain.Entities.Genero> Genero { get; set; }
            public DbSet<Modules.Orientacion.Domain.Entities.Orientacion> Orientacion { get; set; }
            public DbSet<Modules.Busca.Domain.Entities.Busca> Busca { get; set; }
            public DbSet<Modules.Likes.Domain.Entities.Likes> Likes { get; set; }
            public DbSet<Modules.Matches.Domain.Entities.Matches> Matches { get; set; }
            public DbSet<Modules.Intereses.Domain.Entities.Intereses> Intereses { get; set; }
            public DbSet<Modules.Dislikes.Domain.Entities.Dislikes> Dislikes { get; set; }
            public DbSet<Modules.InteresesUsuario.Domain.Entities.InteresesUsuario> InteresesUsuario { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}