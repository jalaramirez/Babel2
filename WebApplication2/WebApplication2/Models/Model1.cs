using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model2")
        {
        }

        public virtual DbSet<CLIENTES> CLIENTES { get; set; }
        public virtual DbSet<COBERTURA> COBERTURA { get; set; }
        public virtual DbSet<PLANES> PLANES { get; set; }
        public virtual DbSet<REL_CLIENTE_PLAN> REL_CLIENTE_PLAN { get; set; }
        public virtual DbSet<REL_PLAN_COBER> REL_PLAN_COBER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.APPATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES>()
                .Property(e => e.APMATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<COBERTURA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<COBERTURA>()
                .HasMany(e => e.REL_PLAN_COBER)
                .WithRequired(e => e.COBERTURA)
                .HasForeignKey(e => e.IDCOBER);

            modelBuilder.Entity<PLANES>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);
        }
    }
}
