using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Intereses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class InteresesConfigurations : IEntityTypeConfiguration<Intereses>
    {
        public void Configure(EntityTypeBuilder<Intereses> builder)
        {
            builder.ToTable("intereses");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.interes).IsRequired().HasMaxLength(20);
            builder.Property(i => i.descripcion).IsRequired();
            builder.HasMany(i => i.InteresesUsuario)
                .WithOne(u => u.interes)
                .HasForeignKey(u => u.Id_interes);
        }
    }
}