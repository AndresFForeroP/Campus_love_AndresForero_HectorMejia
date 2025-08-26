using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Orientacion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class OrientacionConfigurations : IEntityTypeConfiguration<Orientacion>
    {
        public void Configure(EntityTypeBuilder<Orientacion> builder)
        {
            builder.ToTable("orientacion");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.orientacion).IsRequired().HasMaxLength(50);
            builder.HasMany(o => o.usuarios)
                .WithOne(u => u.orientacion)
                .HasForeignKey(u => u.Id_orientacion);
        }
    }
}