using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Genero.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("genero");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.genero).IsRequired().HasMaxLength(25);
            builder.HasMany(b => b.usuarios)
                .WithOne(u => u.genero)
                .HasForeignKey(b => b.Id_Genero);
        }
    }
}