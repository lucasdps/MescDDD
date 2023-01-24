using DalpiazDDD.Domain.Entitys;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }
       

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<ConjuntoEntrada> ConjuntoEntradas { get; set; }

        public DbSet<ConjuntoResultado> ConjuntoResultados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConjuntoEntrada>().ToTable("tb_conjunto_entrada");
            modelBuilder.Entity<ConjuntoEntrada>().HasKey(b => b.Id);
            modelBuilder.Entity<ConjuntoEntrada>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<ConjuntoEntrada>().Property(b => b.Descricao).HasColumnName("descricao");
            modelBuilder.Entity<ConjuntoEntrada>().Property(b => b.Entrada).HasColumnName("entrada").HasColumnType("jsonb");
            modelBuilder.Entity<ConjuntoEntrada>().Property(b => b.DataCadastro).HasColumnName("data_cadastro");


            modelBuilder.Entity<ConjuntoResultado>().ToTable("tb_conjunto_resultado");
            modelBuilder.Entity<ConjuntoResultado>().HasKey(b => b.Id);
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.Descricao).HasColumnName("descricao");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.AnaliseResultado).HasColumnName("analise_resultado").HasColumnType("jsonb");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.DataCadastro).HasColumnName("data_cadastro");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.IdConjuntoEntrada).HasColumnName("id_conjunto_entrada");
            modelBuilder.Entity<ConjuntoResultado>().HasOne(fk => fk.ConjuntoEntrada).WithMany(c=>c.ConjuntoResultados).HasForeignKey(fkey=>fkey.IdConjuntoEntrada);

            //modelBuilder.Entity<ConjuntoResultado>().ToTable("tb_conjunto_resultado")
            //    .Property(b => b.AnaliseResultado)
            //.HasColumnType("jsonb");
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            return base.SaveChanges();
        }
    }
}
