using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Likes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class LikesConfigurations : IEntityTypeConfiguration<Likes>
    {
        public void Configure(EntityTypeBuilder<Likes> builder)
        {
            builder.ToTable("likes");
            builder.HasKey(d => new { d.Id_usuario_darlike, d.Id_usuario_recibirlike });
            builder.HasOne(d => d.usuario_darlike)
                .WithMany(u => u.likesdados)
                .HasForeignKey(d => d.Id_usuario_darlike)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.usuario_recibirlike)
                .WithMany(u => u.likesrecibidos)
                .HasForeignKey(d => d.Id_usuario_recibirlike)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}