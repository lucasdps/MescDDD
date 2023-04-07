using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using DalpiazDDD.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceConjuntoResultado : IServiceBase<ConjuntoResultado>
    {
        IEnumerable<ConjuntoResultado> ListarByEntrada(int idConjuntoEntrada);
        ConjuntoResultado Resultado(int id);
        IEnumerable<ConjuntoResultado> ResultadosSemListasInternas();

        dynamic LitarView(int idOperacao, TipoViewResultado tp);
    }
}
