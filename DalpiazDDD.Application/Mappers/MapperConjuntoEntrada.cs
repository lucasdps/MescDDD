using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Mappers
{
    public class MapperConjuntoEntrada : IMapperConjuntoEntrada
    {
        public ConjuntoEntrada MapperDtoToEntityAdd(ConjuntoEntradaCadastroDto conjuntoEntradaDto)
        {


            var entrada = new Entrada();
            entrada.MontarEntrada(conjuntoEntradaDto.Path);
            return new ConjuntoEntrada
            {
                DataCadastro = conjuntoEntradaDto.DataCadastro,
                Descricao = conjuntoEntradaDto.Descricao,
                Entrada = entrada
            };
           
        }

        public ConjuntoEntrada MapperDtoToEntity(ConjuntoEntradaDto conjuntoEntradaDto)
        {


            return new ConjuntoEntrada
            {
                DataCadastro = conjuntoEntradaDto.DataCadastro,
                Descricao = conjuntoEntradaDto.Descricao,
                Entrada = conjuntoEntradaDto.Entrada,
                Id = conjuntoEntradaDto.Id
            };

        }

        public ConjuntoEntradaDto MapperEntityToDto(ConjuntoEntrada conjuntoEntrada)
        {
            return new ConjuntoEntradaDto 
            {
                Id = conjuntoEntrada.Id,
                Entrada = conjuntoEntrada.Entrada,
                Descricao = conjuntoEntrada.Descricao,
                DataCadastro = conjuntoEntrada.DataCadastro
            };
        }

        public IEnumerable<ConjuntoEntradaDto> MapperListFuncionariosDto(IEnumerable<ConjuntoEntrada> conjuntoEntradas)
        {
            List<ConjuntoEntradaDto> retorno = new List<ConjuntoEntradaDto>();
            conjuntoEntradas.ToList().ForEach( item => {
                retorno.Add(new ConjuntoEntradaDto 
                { 
                    Id = item.Id,
                    DataCadastro = item.DataCadastro,
                    Descricao = item.Descricao,
                    Entrada = item.Entrada
                });
            });
            return retorno;


        }

        public ConjuntoEntradaPrevisualizacaoDto MapperEntityToDtoPrevisualizacao(ConjuntoEntrada conjuntoEntrada)
        {
            return new ConjuntoEntradaPrevisualizacaoDto 
            {
                Descricao = conjuntoEntrada.Descricao,
                Id = conjuntoEntrada.Id,
                P1 = conjuntoEntrada.Entrada.P1,
                P2 = conjuntoEntrada.Entrada.P2,
                P3 = conjuntoEntrada.Entrada.P3 ,
                QtdEquipamentos = conjuntoEntrada.Entrada.QtdEquipamentos,
                QtdFP = conjuntoEntrada.Entrada.QtdFP,
                QtdFS = conjuntoEntrada.Entrada.QtdFS,
                QtdOperacoes = conjuntoEntrada.Entrada.QtdOperacoes
            };
        }

        public IEnumerable<ConjuntoEntradaPrevisualizacaoDto> MapperListConjuntoEntradaPrevisualizacaoDto(IEnumerable<ConjuntoEntrada> conjuntoEntradas)
        {
            List<ConjuntoEntradaPrevisualizacaoDto> retorno = new List<ConjuntoEntradaPrevisualizacaoDto>();
            conjuntoEntradas.ToList().ForEach(item => {
                retorno.Add(new ConjuntoEntradaPrevisualizacaoDto
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    QtdOperacoes = item.Entrada.QtdOperacoes,
                    QtdFS = item.Entrada.QtdFS,
                    QtdFP = item.Entrada.QtdFP,
                    QtdEquipamentos = item.Entrada.QtdEquipamentos,
                    P3 = item.Entrada.P3,
                    P1 = item.Entrada.P1,
                    P2 = item.Entrada.P2
                });
            });
            return retorno;
        }
    }
}
