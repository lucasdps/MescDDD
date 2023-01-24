using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces.Mappers
{
    public interface IMapperConjuntoEntrada
    {
        ConjuntoEntrada MapperDtoToEntityAdd(ConjuntoEntradaCadastroDto conjuntoEntradaCadastroDto);
        ConjuntoEntrada MapperDtoToEntity(ConjuntoEntradaDto conjuntoEntradaDto);


        IEnumerable<ConjuntoEntradaDto> MapperListFuncionariosDto(IEnumerable<ConjuntoEntrada> conjuntoEntradas);
        IEnumerable<ConjuntoEntradaPrevisualizacaoDto> MapperListConjuntoEntradaPrevisualizacaoDto(IEnumerable<ConjuntoEntrada> conjuntoEntradas);

        ConjuntoEntradaDto MapperEntityToDto(ConjuntoEntrada conjuntoEntrada);
        ConjuntoEntradaPrevisualizacaoDto MapperEntityToDtoPrevisualizacao(ConjuntoEntrada conjuntoEntrada);
    }
}
