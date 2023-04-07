using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using DalpiazDDD.Domain.Enuns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Services
{
    public class ServiceConjuntoResultado : ServiceBase<ConjuntoResultado>, IServiceConjuntoResultado
    {
        private readonly IRepositoryConjuntoResultado repositoryConjuntResultado;
        public ServiceConjuntoResultado(IRepositoryConjuntoResultado repositoryConjuntoResultado) : base(repositoryConjuntoResultado)
        {
            this.repositoryConjuntResultado = repositoryConjuntoResultado;
        }


        public IEnumerable<ConjuntoResultado> ListarByEntrada(int idConjuntoEntrada)
        {
           return repositoryConjuntResultado.Contexto()
                .Include(i => i.u_o)
                .Include(i => i.x)
                .Include(i => i.u_fp_o)
                .Include(i => i.u_fs_o)
                .Where(x => x.IdConjuntoEntrada == idConjuntoEntrada).ToArray();
        }

        public ConjuntoResultado Resultado(int id)
        {
            return repositoryConjuntResultado.Contexto()
                .Include(i=>i.u_o)
                .Single(x => x.Id == id);
        }

        public IEnumerable< ConjuntoResultado> ResultadosSemListasInternas()
        {
            return repositoryConjuntResultado.Contexto().ToArray();
        }

        public dynamic LitarView(int idOperacao, TipoViewResultado tp)
        {
            return repositoryConjuntResultado.LitarView(idOperacao, tp);
        }

    }
}
