using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Mappers
{
    public class MapperFuncionario : IMapperFuncionario
    {
        private IList<FuncionarioDto> funcionarioDtos = new List<FuncionarioDto>();

        public Funcionario MapperDtoToEntity(FuncionarioDto funcionarioDto)
        {
            

            var funcionario = new Funcionario()
            {
                Id = funcionarioDto.Id,
                AreaAtuacao = funcionarioDto.AreaAtuacao,
                Cargo = funcionarioDto.Cargo,
                DataAdmissao = Convert.ToDateTime( funcionarioDto.DataAdmissao),
                Matricula = funcionarioDto.Matricula,
                SalarioBruto = Helper.StringToDecimal(funcionarioDto.SalarioBruto),
                Nome = funcionarioDto.Nome,
                TotalPL = Helper.StringToDecimal(funcionarioDto.TotalPL)
            };

            return funcionario;
        }

        public FuncionarioDto MapperEntityToDto(Funcionario funcionario)
        {
            var funcionarioDto = new FuncionarioDto
            { 
                Id=funcionario.Id,
                Nome= funcionario.Nome,
                Matricula= funcionario.Matricula,
                Cargo = funcionario.Cargo,
                AreaAtuacao = funcionario.AreaAtuacao,
                SalarioBruto= funcionario.SalarioBruto.ToString().Replace(",", "."),
                DataAdmissao = funcionario.DataAdmissao.ToString("yyyy-MM-dd"),
                TotalPL = funcionario.TotalPL.ToString().Replace(",", ".")
            };

            return funcionarioDto;
        }

        public IEnumerable<FuncionarioDto> MapperListFuncionariosDto(IEnumerable<Funcionario> funcionarios)
        {
            var dto = funcionarios.Select(funcionario =>
                new FuncionarioDto
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Matricula = funcionario.Matricula,
                    Cargo = funcionario.Cargo,
                    AreaAtuacao = funcionario.AreaAtuacao,
                    SalarioBruto = funcionario.SalarioBruto.ToString().Replace(",","."),
                    DataAdmissao = funcionario.DataAdmissao.ToString("yyyy-MM-dd"),
                    TotalPL = funcionario.TotalPL.ToString().Replace(",", ".")
                });

            return dto;
        }
    }
}
