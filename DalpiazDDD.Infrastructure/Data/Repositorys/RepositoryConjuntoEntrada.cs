using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DalpiazDDD.Infrastructure.Data.Repositorys
{
    public class RepositoryConjuntoEntrada : RepositoryBase<ConjuntoEntrada>, IRepositoryConjuntoEntrada
    {
        private readonly SqlContext sqlContext;

        public RepositoryConjuntoEntrada(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }


        public IEnumerable<Operacao> ListaOperacoes (int idEntrada)
        {

            var r = from i in this.sqlContext.ConjuntoEntradas
                    where i.Id == idEntrada
                    select i.Operacoes;
                    //select new { i.Entrada.Operacoes };


            
            return r.FirstOrDefault().ToArray();
         
        }

        public ConjuntoEntrada UltimoAdicionado()
        {

            var r = this.sqlContext.ConjuntoEntradas.OrderByDescending(x => x.Id).First();
                 

            return r;

        }
    }
}
