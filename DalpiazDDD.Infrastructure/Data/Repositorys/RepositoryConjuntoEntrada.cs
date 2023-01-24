using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
