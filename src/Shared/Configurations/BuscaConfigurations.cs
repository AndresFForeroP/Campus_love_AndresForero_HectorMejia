using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus_love_AndresForero_HectorMejia.src.Modules.Busca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campus_love_AndresForero_HectorMejia.src.Shared.Configurations
{
    public class BuscaConfigurations : IEntityTypeConfiguration<Busca>
    {
        public void Configure(EntityTypeBuilder<Busca> builder)
        {
            builder.ToTable("busca");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.busca).IsRequired().HasMaxLength(100);
            builder.HasMany(b => b.usuarios)
                .WithOne(u => u.busca)
                .HasForeignKey(b => b.Id_busca);
        }
    }
}
