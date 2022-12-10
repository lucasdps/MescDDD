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
    public class MapperCalculoFuncionario : IMapperCalculoFuncionario
    {
        public CalculoFuncionarioDto MapperToCalculoFuncionarioDto(CalculoFuncionario CalculoFuncionarios)
        {
            var dto =
               new CalculoFuncionarioDto
               {
                   TotalDisponibilizado = CalculoFuncionarios.TotalDisponibilizado,
                   TotalDistribuido = CalculoFuncionarios.TotalDistribuido,
                   TotalFuncionarios = CalculoFuncionarios.TotalFuncionarios,
                   MontanteLucro = CalculoFuncionarios.MontanteLucro,
                   Saldo = CalculoFuncionarios.Saldo
               };

            var funcionariosDto = CalculoFuncionarios.funcionarios.Select(cf =>
            new FuncionarioDto
            {
                Id = cf.Id,
                Nome = cf.Nome,
                Matricula = cf.Matricula,
                Cargo = cf.Cargo,
                AreaAtuacao = cf.AreaAtuacao,
                SalarioBruto = cf.SalarioBruto.ToString().Replace(",", "."),
                DataAdmissao = cf.DataAdmissao.ToString("yyyy-MM-dd"),
                TotalPL= cf.TotalPL.ToString().Replace(",", ".")
            });

            dto.funcionariosDtos = funcionariosDto;
            return dto;
        }
    }
}
