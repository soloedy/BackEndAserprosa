using aserprosa.Entidades.Finca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace aserprosa.Datos.Maping.Finca
{
    public class ase_fincaMap : IEntityTypeConfiguration<ase_finca>
    {
        public void Configure(EntityTypeBuilder<ase_finca> builder)
        {
            builder.ToTable("ase_finca")
                .HasKey(f => f.finc_id);
        }
    }
}
