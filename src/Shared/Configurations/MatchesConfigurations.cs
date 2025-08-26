using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Matches.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class MatchesConfigurations : IEntityTypeConfiguration<Matches>
    {
        public void Configure(EntityTypeBuilder<Matches> builder)
        {
            builder.ToTable("matches");
            builder.HasKey(m => new { m.Id_primer_usuario, m.Id_segundo_usuario });
            builder.HasOne(m => m.primerusuario)
                .WithMany(u => u.matches_1)
                .HasForeignKey(m => m.Id_primer_usuario);
            builder.HasOne(m => m.segundoUsuario)
                .WithMany(u => u.matches_2)
                .HasForeignKey(m => m.Id_segundo_usuario);
        }
    }
}