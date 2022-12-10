using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application
{
    public class ApplicationServiceCalculoFuncionario :  IApplicationServiceCalculoFuncionario
    {
        
        private readonly IServiceCalculoFuncionario serviceCalculoFuncionario;
        private readonly IMapperCalculoFuncionario mapperCalculoFuncionario;

        public ApplicationServiceCalculoFuncionario(
            IServiceCalculoFuncionario serviceCalculoFuncionario,
            IMapperCalculoFuncionario mapperCalculoFuncionario)
        {
            this.serviceCalculoFuncionario = serviceCalculoFuncionario;
            this.mapperCalculoFuncionario = mapperCalculoFuncionario;
        }

        public CalculoFuncionarioDto CalculoFuncionarioPL(decimal montanteLucro)
        {
            var ctot= serviceCalculoFuncionario.CalcularTotais(montanteLucro);
            var r = mapperCalculoFuncionario.MapperToCalculoFuncionarioDto(ctot);
            return r;
        }

        
    }
}
