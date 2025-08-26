using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.InteresesUsuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class InteresesUsuarioConfigurations : IEntityTypeConfiguration<InteresesUsuario>
    {
        public void Configure(EntityTypeBuilder<InteresesUsuario> builder)
        {
            builder.ToTable("interesesusuarios");
            builder.HasKey(iu => new { iu.Id_usuario, iu.Id_interes });
            builder.HasOne(iu => iu.interes)
                .WithMany(i => i.InteresesUsuario)
                .HasForeignKey(iu => iu.Id_interes);
            builder.HasOne(iu => iu.usuario)
                .WithMany(u => u.InteresesUsuario)
                .HasForeignKey(iu => iu.Id_usuario);
        }
    }
}