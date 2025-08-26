using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Usuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.nombre).IsRequired().HasMaxLength(100);
            builder.Property(u => u.usuario).IsRequired().HasMaxLength(100);
            builder.Property(u => u.contraseña).IsRequired().HasMaxLength(100);
            builder.Property(u => u.edad).IsRequired();
            builder.Property(u => u.Id_Genero).IsRequired();
            builder.HasOne(u => u.genero)
                .WithMany(g => g.usuarios)
                .HasForeignKey(u => u.Id_Genero);
            builder.Property(u => u.carrera).IsRequired().HasMaxLength(100);
            builder.Property(u => u.frase).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Id_orientacion).IsRequired();
            builder.HasOne(u => u.orientacion)
                .WithMany(o => o.usuarios)
                .HasForeignKey(u => u.Id_orientacion);
            builder.Property(u => u.Id_busca).IsRequired();
            builder.HasOne(u => u.busca)
                .WithMany(b => b.usuarios)
                .HasForeignKey(u => u.Id_busca);
            builder.HasMany(u => u.likesdados)
                .WithOne(l => l.usuario_darlike)
                .HasForeignKey(l => l.Id_usuario_darlike);
            builder.HasMany(u => u.likesrecibidos)
                .WithOne(l => l.usuario_recibirlike)
                .HasForeignKey(l => l.Id_usuario_recibirlike);
            builder.HasMany(u => u.matches_1)
                .WithOne(m => m.primerusuario)
                .HasForeignKey(m => m.Id_primer_usuario);
            builder.HasMany(u => u.matches_2)
                .WithOne(m => m.segundoUsuario)
                .HasForeignKey(m => m.Id_segundo_usuario);
            builder.HasMany(u => u.InteresesUsuario)
                .WithOne(i => i.usuario)
                .HasForeignKey(i => i.Id_usuario);
            builder.HasMany(u => u.dislikedados)
                .WithOne(d => d.usuario_dardislike)
                .HasForeignKey(d => d.Id_usuario_dardislike);
            builder.HasMany(u => u.dislikerecibidos)
                .WithOne(d => d.usuario_recibirdislike)
                .HasForeignKey(d => d.Id_usuario_recibirdislike);
        }
    }
}