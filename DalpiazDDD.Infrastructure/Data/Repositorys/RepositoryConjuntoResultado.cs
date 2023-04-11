using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using DalpiazDDD.Domain.Enuns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Infrastructure.Data.Repositorys
{
    public class RepositoryConjuntoResultado : RepositoryBase<ConjuntoResultado>, IRepositoryConjuntoResultado
    {
        private readonly SqlContext sqlContext;

        public RepositoryConjuntoResultado(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public DbSet<ConjuntoResultado> Contexto() { return sqlContext.ConjuntoResultados; }

        public dynamic LitarView(int idOperacao, TipoViewResultado tp)
        {

            if (tp == TipoViewResultado.OperacoesDias)
            {
                var listU_o = from cr in this.sqlContext.ConjuntoResultados
                              where cr.Id == idOperacao
                              select new { u_o = cr.u_o, idEntrada = cr.IdConjuntoEntrada };

                var entrada = from i in this.sqlContext.ConjuntoEntradas
                        where i.Id == listU_o.First().idEntrada
                        select i;


                var operacao = entrada.First().Operacoes;
                var u_o = listU_o.First().u_o;

                var r = operacao.Join(u_o, o => o.Id, u => u.OperacaoId+1, (o, u) =>
                new  
                { 
                    Id = "O." + o.Id + ".",
                    DataInicio = "DI."+o.DataInicio + ".",
                    DataFim ="DF." + o.DataFim + ".",
                    Equipamento = "",
                    Fp = "",
                    Fs = "",
                    Realizado = u.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToList();

                return new { data = r};

            }
            else if (tp == TipoViewResultado.EquipamentosDias)
            {
                var listU_o = from cr in this.sqlContext.ConjuntoResultados
                              where cr.Id == idOperacao
                              select new { x = cr.x, idEntrada = cr.IdConjuntoEntrada };

                var entrada = from i in this.sqlContext.ConjuntoEntradas
                              where i.Id == listU_o.First().idEntrada
                              select i;


                var operacao = entrada.First().Operacoes;
                var x = listU_o.First().x.Where(x=>x.Realizada == 1);

                var r = operacao.Join(x, o => o.Id, u => u.OperacaoId + 1, (o, u) =>
                new
                {
                    Id = "O." + o.Id + ".",
                    DataInicio = "DI." + o.DataInicio + ".",
                    DataFim = "DF." + o.DataFim + ".",
                    Equipamento = "EQ." + u.EquipamentoId + 1 + ".",
                    Fp = "",
                    Fs = "",
                    Realizado = u.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToList();

                return new { data = r };
            }
            else if (tp == TipoViewResultado.FpDias)
            {
                var list_u_fp_o = from cr in this.sqlContext.ConjuntoResultados
                              where cr.Id == idOperacao
                              select  cr.u_fp_o;
                var list_x= from cr in this.sqlContext.ConjuntoResultados
                                  where cr.Id == idOperacao
                                  select cr.x;
                var list_entrada = from cr in this.sqlContext.ConjuntoResultados
                                  where cr.Id == idOperacao
                                  select cr.ConjuntoEntrada;

                var entrada = from i in this.sqlContext.ConjuntoEntradas
                              where i.Id == list_entrada.First().Id
                              select i;


                var operacao = entrada.First().Operacoes;
                var u_fp_o = list_u_fp_o.First().Where(x => x.Realizada == 1);
                var x = list_x.First().Where(x => x.Realizada == 1);

                var _r = operacao.Join(x, o => o.Id, u => u.OperacaoId + 1, (o, u) =>
                new
                {
                    Id = o.Id,
                    DataInicio = o.DataInicio ,
                    DataFim =  o.DataFim ,
                    Equipamento = u.EquipamentoId+1,
                    Fp = "",
                    Fs = "",
                    Realizado = u.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToArray();


                var r = u_fp_o.Join(_r, o => o.OperacaoId+1, u => u.Id, (o, u) =>
                new
                {
                    Id = "O." + u.Id + ".",
                    DataInicio = "DI." + u.DataInicio + ".",
                    DataFim = "DF." + u.DataFim + ".",
                    Equipamento = "EQ." + u.Equipamento + ".",
                    Fp = "FP." + o.FpId + 1 + ".",
                    Fs = "",
                    Realizado = o.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToList();

                return new { data = r };
            }
            else if (tp == TipoViewResultado.FsDias)
            {
                var list_u_fs_o = from cr in this.sqlContext.ConjuntoResultados
                                  where cr.Id == idOperacao
                                  select cr.u_fs_o;
                var list_u_fp_o = from cr in this.sqlContext.ConjuntoResultados
                                  where cr.Id == idOperacao
                                  select cr.u_fp_o;
                var list_x = from cr in this.sqlContext.ConjuntoResultados
                             where cr.Id == idOperacao
                             select cr.x;
                var list_entrada = from cr in this.sqlContext.ConjuntoResultados
                                   where cr.Id == idOperacao
                                   select cr.ConjuntoEntrada;

                var entrada = from i in this.sqlContext.ConjuntoEntradas
                              where i.Id == list_entrada.First().Id
                              select i;


                var operacao = entrada.First().Operacoes;
                var u_fs_o = list_u_fs_o.First().Where(x => x.Realizada == 1);
                var u_fp_o = list_u_fp_o.First().Where(x => x.Realizada == 1);
                var x = list_x.First().Where(x => x.Realizada == 1);

                var _r = operacao.Join(x, o => o.Id, u => u.OperacaoId + 1, (o, u) =>
                new
                {
                    Id = o.Id,
                    DataInicio = o.DataInicio,
                    DataFim = o.DataFim,
                    Equipamento = u.EquipamentoId + 1,
                    Fp = "",
                    Fs = "",
                    Realizado = u.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToArray();


                var r = u_fp_o.Join(_r, o => o.OperacaoId + 1, u => u.Id, (o, u) =>
                new
                {
                    Id = u.Id,
                    DataInicio = u.DataInicio,
                    DataFim =  u.DataFim ,
                    Equipamento =  u.Equipamento,
                    Fp =  o.FpId + 1 ,
                    Fs = "",
                    Realizado = o.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToList();


                var s = u_fs_o.Join(r, o => o.OperacaoId + 1, u => u.Id, (o, u) =>
                new
                {
                    Id = "O." + (u.Id+1) + ".",
                    DataInicio = "DI." + u.DataInicio + ".",
                    DataFim = "DF." + u.DataFim + ".",
                    Equipamento = "EQ." + u.Equipamento + ".",
                    Fp = "FP." + u.Fp  + ".",
                    Fs = "FS." + (o.FsId + 1 )+ ".",
                    Realizado = o.Realizada == 1 ? "Sim" : "Não"
                }
                ).ToList();

                return new { data = s };

            }

            

            
            return null;
        }

        
    }
}
