using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Services
{
    public class ServiceConjuntoEntrada : ServiceBase<ConjuntoEntrada>, IServiceConjuntoEntrada
    {
        private readonly IRepositoryConjuntoEntrada repositoryConjuntoEntrada;
        public ServiceConjuntoEntrada(IRepositoryConjuntoEntrada repositoryConjuntoEntrada) : base(repositoryConjuntoEntrada)
        {
            this.repositoryConjuntoEntrada = repositoryConjuntoEntrada;
        }

        public IEnumerable<Operacao> ListaOperacoes(int idEntrada)
        {
            return this.repositoryConjuntoEntrada.ListaOperacoes(idEntrada);

        }

        public ConjuntoEntrada UltimoAdicionado()
        {
            return this.repositoryConjuntoEntrada.UltimoAdicionado();
        }
    }
}
