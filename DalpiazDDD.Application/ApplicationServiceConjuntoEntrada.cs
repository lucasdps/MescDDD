using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application
{
    public class ApplicationServiceConjuntoEntrada : IApplicationServiceConjuntoEntrada
    {
        private readonly IServiceConjuntoEntrada serviceConjuntoEntrada;
        private readonly IMapperConjuntoEntrada mapperConjuntoEntrada;

        public ApplicationServiceConjuntoEntrada(
             IServiceConjuntoEntrada serviceConjuntoEntrada,
            IMapperConjuntoEntrada mapperConjuntoEntrada)
        {
            this.serviceConjuntoEntrada = serviceConjuntoEntrada;
            this.mapperConjuntoEntrada = mapperConjuntoEntrada;
        }

        public void Add(ConjuntoEntradaCadastroDto conjuntoEntradaCadastroDto)
        {
            //conjuntoEntradaDto.Id = null;
            conjuntoEntradaCadastroDto.DataCadastro = DateTime.Now;
            var conjuntoEntrada = mapperConjuntoEntrada.MapperDtoToEntityAdd(conjuntoEntradaCadastroDto);

            var aux = new ConjuntoEntrada();
            //aux.COL_OPER = conjuntoEntrada.COL_OPER;

            //conjuntoEntrada.COL_OPER = null;



            serviceConjuntoEntrada.Add(conjuntoEntrada);

            //var ultimo = serviceConjuntoEntrada.UltimoAdicionado();
            //ultimo.COL_OPER = aux.COL_OPER;
            //serviceConjuntoEntrada.Update(ultimo);


        }

        public IEnumerable<ConjuntoEntradaDto> GetAll()
        {
            var conjuntoEntradasDto = serviceConjuntoEntrada.GetAll();
            return mapperConjuntoEntrada.MapperListFuncionariosDto(conjuntoEntradasDto);
        }

        public IEnumerable<ConjuntoEntradaPrevisualizacaoDto> GetAllPrevisualizacao()
        {
            var conjuntoEntradasDto = serviceConjuntoEntrada.GetAll();
            return mapperConjuntoEntrada.MapperListConjuntoEntradaPrevisualizacaoDto(conjuntoEntradasDto);
        }

        public ConjuntoEntradaDto GetById(int id)
        {
            var conjuntoEntrada = serviceConjuntoEntrada.GetById(id);
            return mapperConjuntoEntrada.MapperEntityToDto(conjuntoEntrada);
        }

        public ConjuntoEntrada GetByIdCompleto(int id)
        {
            return serviceConjuntoEntrada.GetById(id);
        }

        public ConjuntoEntradaPrevisualizacaoDto GetByIdPrevisualizacao(int id)
        {
            var conjuntoEntrada = serviceConjuntoEntrada.GetById(id);
            return mapperConjuntoEntrada.MapperEntityToDtoPrevisualizacao(conjuntoEntrada);
        }

        public IEnumerable<Operacao> ListaOperacoes(int idEntrada)
        {
           return serviceConjuntoEntrada.ListaOperacoes(idEntrada);
        }

        public void Remove(int id)
        {
            var conjuntoEntrada = serviceConjuntoEntrada.GetById(id);
            serviceConjuntoEntrada.Remove(conjuntoEntrada);
        }

        public void Update(ConjuntoEntradaDto conjuntoEntradaDto)
        {
            var conjuntoEntrada = mapperConjuntoEntrada.MapperDtoToEntity(conjuntoEntradaDto);
            serviceConjuntoEntrada.Update(conjuntoEntrada);
        }
    }
}
