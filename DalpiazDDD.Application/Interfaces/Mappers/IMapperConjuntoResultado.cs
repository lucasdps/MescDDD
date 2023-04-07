using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces.Mappers
{
    public interface IMapperConjuntoResultado
    {
        ConjuntoResultado MapperDtoToEntity(ConjuntoResultadoDto conjuntoResultadoDto);

        ConjuntoResultadoDto EntityToMapperDto(ConjuntoResultado conjuntoResultado);
ConjuntoResultadoDto EntityToMapperDtoSemInclude(ConjuntoResultado conjuntoResultado);

        IEnumerable<ConjuntoResultadoDto> MapperListResultadosDto(IEnumerable<ConjuntoResultado> conjuntoResultado);

    }
}
