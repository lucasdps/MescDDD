using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using DalpiazDDD.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces
{
    public interface IApplicationServiceConjuntoResultado
    {
        IEnumerable<ConjuntoResultadoDto> ListarByEntrada(int idConjuntoEntrada);
        ConjuntoResultadoDto Resultado(int id);

        IEnumerable<ConjuntoResultadoDto> ResultadosSemListasInternas();

        dynamic LitarView(int idOperacao, TipoViewResultado tp);
    }
}
