using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
