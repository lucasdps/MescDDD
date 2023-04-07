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
        public DbSet<AnaliseOperacao> AnaliseOperacoes { get; set; }
        public DbSet<AnaliseOperacaoEquipamento> AnaliseOperacaoEquipamentos { get; set; }

        public DbSet<AnaliseOperacaoFP> AnaliseOperacaoFPs { get; set; }
        public DbSet<AnaliseOperacaoFS> AnaliseOperacaoFSs { get; set; }

        public DbSet<AnaliseOperacaoEquipamentoFP> AnaliseOperacaoEquipamentoFPs { get; set; }
        public DbSet<AnaliseOperacaoEquipamentoFS> AnaliseOperacaoEquipamentoFSs { get; set; }
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
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.DataCadastro).HasColumnName("data_cadastro");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.IdConjuntoEntrada).HasColumnName("id_conjunto_entrada");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.ValorFuncaoObjetivo).HasColumnName("valor_funcao_objetivo");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.Nodes).HasColumnName("nodes");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.Iteracoes).HasColumnName("iteracoes");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.Status).HasColumnName("status");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.TempoMilisegundos).HasColumnName("tempo_milisegundos");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.QtdVariaveis).HasColumnName("qtd_variaveis");
            modelBuilder.Entity<ConjuntoResultado>().Property(b => b.QtdRestricoes).HasColumnName("qtd_restricoes");
            modelBuilder.Entity<ConjuntoResultado>().HasMany(fk => fk.u_o).WithOne(o => o.ConjuntoResultado);
            modelBuilder.Entity<ConjuntoResultado>().HasMany(fk => fk.x).WithOne(o => o.ConjuntoResultado);
            modelBuilder.Entity<ConjuntoResultado>().HasMany(fk => fk.u_fp_o).WithOne(o => o.ConjuntoResultado);
            modelBuilder.Entity<ConjuntoResultado>().HasMany(fk => fk.u_fs_o).WithOne(o => o.ConjuntoResultado);
            //modelBuilder.Entity<ConjuntoResultado>().HasMany(fk => fk.z).WithOne(o => o.ConjuntoResultado);
            //modelBuilder.Entity<ConjuntoResultado>().HasMany(fk => fk.y).WithOne(o => o.ConjuntoResultado);
            modelBuilder.Entity<ConjuntoResultado>().HasOne(fk => fk.ConjuntoEntrada).WithMany(c=>c.ConjuntoResultados).HasForeignKey(f=>f.IdConjuntoEntrada);

            modelBuilder.Entity<AnaliseOperacao>().ToTable("tb_analise_operacao");
            modelBuilder.Entity<AnaliseOperacao>().HasKey(b => b.Id);
            modelBuilder.Entity<AnaliseOperacao>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<AnaliseOperacao>().Property(b => b.OperacaoId).HasColumnName("operacao_id");
            modelBuilder.Entity<AnaliseOperacao>().Property(b => b.Realizada).HasColumnName("realizada");
            modelBuilder.Entity<AnaliseOperacao>().Property(b => b.ConjuntoResultadoId).HasColumnName("id_conjunto_resultado");

            modelBuilder.Entity<AnaliseOperacaoEquipamento>().ToTable("tb_analise_operacao_equipamento");
            modelBuilder.Entity<AnaliseOperacaoEquipamento>().HasKey(b => b.Id);
            modelBuilder.Entity<AnaliseOperacaoEquipamento>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<AnaliseOperacaoEquipamento>().Property(b => b.OperacaoId).HasColumnName("operacao_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamento>().Property(b => b.EquipamentoId).HasColumnName("equipamento_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamento>().Property(b => b.Realizada).HasColumnName("realizada");
            modelBuilder.Entity<AnaliseOperacaoEquipamento>().Property(b => b.ConjuntoResultadoId).HasColumnName("id_conjunto_resultado");


            modelBuilder.Entity<AnaliseOperacaoFP>().ToTable("tb_analise_operacao_fp");
            modelBuilder.Entity<AnaliseOperacaoFP>().HasKey(b => b.Id);
            modelBuilder.Entity<AnaliseOperacaoFP>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<AnaliseOperacaoFP>().Property(b => b.OperacaoId).HasColumnName("operacao_id");
            modelBuilder.Entity<AnaliseOperacaoFP>().Property(b => b.FpId).HasColumnName("fp_id");
            modelBuilder.Entity<AnaliseOperacaoFP>().Property(b => b.Realizada).HasColumnName("realizada");
            modelBuilder.Entity<AnaliseOperacaoFP>().Property(b => b.ConjuntoResultadoId).HasColumnName("id_conjunto_resultado");


            modelBuilder.Entity<AnaliseOperacaoFS>().ToTable("tb_analise_operacao_fs");
            modelBuilder.Entity<AnaliseOperacaoFS>().HasKey(b => b.Id);
            modelBuilder.Entity<AnaliseOperacaoFS>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<AnaliseOperacaoFS>().Property(b => b.OperacaoId).HasColumnName("operacao_id");
            modelBuilder.Entity<AnaliseOperacaoFS>().Property(b => b.FsId).HasColumnName("fs_id");
            modelBuilder.Entity<AnaliseOperacaoFS>().Property(b => b.Realizada).HasColumnName("realizada");
            modelBuilder.Entity<AnaliseOperacaoFS>().Property(b => b.ConjuntoResultadoId).HasColumnName("id_conjunto_resultado");

            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().ToTable("tb_analise_operacao_equipamento_fp");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().HasKey(b => b.Id);
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().Property(b => b.OperacaoId).HasColumnName("operacao_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().Property(b => b.EquipamentoId).HasColumnName("equipamento_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().Property(b => b.FpId).HasColumnName("fp_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().Property(b => b.Realizada).HasColumnName("realizada");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFP>().Property(b => b.ConjuntoResultadoId).HasColumnName("id_conjunto_resultado");


            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().ToTable("tb_analise_operacao_equipamento_fs");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().HasKey(b => b.Id);
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().Property(b => b.OperacaoId).HasColumnName("operacao_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().Property(b => b.EquipamentoId).HasColumnName("equipamento_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().Property(b => b.FsId).HasColumnName("fs_id");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().Property(b => b.Realizada).HasColumnName("realizada");
            modelBuilder.Entity<AnaliseOperacaoEquipamentoFS>().Property(b => b.ConjuntoResultadoId).HasColumnName("id_conjunto_resultado");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
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
