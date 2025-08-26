using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Dislikes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class DislikesConfigurations : IEntityTypeConfiguration<Dislikes>
    {
        public void Configure(EntityTypeBuilder<Dislikes> builder)
        {
            builder.ToTable("dislikes");
            builder.HasKey(d => new { d.Id_usuario_dardislike, d.Id_usuario_recibirdislike });
            builder.HasOne(d => d.usuario_dardislike)
                .WithMany(u => u.dislikedados)
                .HasForeignKey(d => d.Id_usuario_dardislike)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.usuario_recibirdislike)
                .WithMany(u => u.dislikerecibidos)
                .HasForeignKey(d => d.Id_usuario_recibirdislike)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}