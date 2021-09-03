using System;
using System.Collections.Generic;
using System.Text;
using aserprosa.Datos.Maping.Finca;
using aserprosa.Entidades.Finca;
using Microsoft.EntityFrameworkCore;

namespace aserprosa.Datos
{
    public class DbContextAserprosa : DbContext
    {
        public DbSet<ase_finca> ase_Finca { get; set; }
        public DbSet<ase_productor> ase_Productor { get; set; }
        public DbContextAserprosa(DbContextOptions<DbContextAserprosa> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ase_fincaMap());
            modelBuilder.ApplyConfiguration(new ase_productorMap());
        }
    }
}
