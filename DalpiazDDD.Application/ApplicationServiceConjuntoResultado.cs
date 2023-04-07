using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application
{
    public class ApplicationServiceConjuntoResultado : IApplicationServiceConjuntoResultado
    {
        private readonly IServiceConjuntoResultado serviceConjuntoResultado;
        private readonly IMapperConjuntoResultado mapperConjuntoResultado;

        public ApplicationServiceConjuntoResultado(
             IServiceConjuntoResultado serviceConjuntoResultado,
            IMapperConjuntoResultado mapperConjuntoResultado)
        {
            this.serviceConjuntoResultado = serviceConjuntoResultado;
            this.mapperConjuntoResultado = mapperConjuntoResultado;

        }

        public IEnumerable<ConjuntoResultadoDto> ListarByEntrada(int idConjuntoEntrada)
        {
           var r = serviceConjuntoResultado.ListarByEntrada(idConjuntoEntrada);

            var lista = new List<ConjuntoResultadoDto>();
            foreach (var item in r)
            {
                lista.Add(mapperConjuntoResultado.EntityToMapperDto(item));
            }
            return lista;
        }

        public ConjuntoResultadoDto Resultado(int id)
        {
            var r = serviceConjuntoResultado.Resultado(id);

            return mapperConjuntoResultado.EntityToMapperDto(r);
        }

        public IEnumerable<ConjuntoResultadoDto> ResultadosSemListasInternas()
        {
            var r = serviceConjuntoResultado.ResultadosSemListasInternas();

            var lista = new List<ConjuntoResultadoDto>();
            foreach (var item in r)
            {
                lista.Add(mapperConjuntoResultado.EntityToMapperDtoSemInclude(item));
            }
            return lista;
        }

        public dynamic LitarView(int idOperacao, TipoViewResultado tp)
        {
            return serviceConjuntoResultado.LitarView(idOperacao, tp);
        }
    }
}
