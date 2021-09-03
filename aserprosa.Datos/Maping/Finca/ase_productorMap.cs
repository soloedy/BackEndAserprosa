using System;
using System.Collections.Generic;
using System.Text;
using aserprosa.Entidades.Finca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aserprosa.Datos.Maping.Finca
{
    public class ase_productorMap : IEntityTypeConfiguration<ase_productor>
    {
        public void Configure(EntityTypeBuilder<ase_productor> builder)
        {
            builder.ToTable("ase_productor")
                .HasKey(p => p.prod_id);
        }
    }
}
