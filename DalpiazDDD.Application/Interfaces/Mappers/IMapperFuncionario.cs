using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces.Mappers
{
    public interface IMapperFuncionario
    {
        Funcionario MapperDtoToEntity(FuncionarioDto funcionarioDto);

        IEnumerable<FuncionarioDto> MapperListFuncionariosDto(IEnumerable<Funcionario> funcionarios);

        FuncionarioDto MapperEntityToDto(Funcionario funcionario);
    }
}
