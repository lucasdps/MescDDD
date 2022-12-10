using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces.Mappers
{
    public  interface IMapperCalculoFuncionario
    {
        CalculoFuncionarioDto MapperToCalculoFuncionarioDto(CalculoFuncionario CalculoFuncionarios);

    }
}
