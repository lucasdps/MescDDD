using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Services;

namespace DalpiazDDD.Application
{
    public class AplicationServiceFuncionario : IApplicationServiceFuncionario
    {
        private readonly IServiceFuncionario serviceFuncionario;
        private readonly IMapperFuncionario mapperFuncionario;

        public AplicationServiceFuncionario(
            IServiceFuncionario serviceFuncionario,
            IMapperFuncionario mapperFuncionario)
        {
            this.serviceFuncionario = serviceFuncionario;
            this.mapperFuncionario = mapperFuncionario;
        }

        public void Add(FuncionarioDto funcionarioDto)
        {
            funcionarioDto.Id = null;
            var funcionario = mapperFuncionario.MapperDtoToEntity(funcionarioDto);
            serviceFuncionario.Add(funcionario);
        }

        public IEnumerable<FuncionarioDto> GetAll()
        {
            var funcionariosDto = serviceFuncionario.GetAll();
            return mapperFuncionario.MapperListFuncionariosDto(funcionariosDto);
        }

        public FuncionarioDto GetById(int id)
        {
            var funcionario = serviceFuncionario.GetById(id);
            return mapperFuncionario.MapperEntityToDto(funcionario);
        }

        public void Remove(int id)
        {
            var funcionario = serviceFuncionario.GetById(id);
            serviceFuncionario.Remove(funcionario);
        }

        public void Update(FuncionarioDto funcionarioDto)
        {
            var funcionario = mapperFuncionario.MapperDtoToEntity(funcionarioDto);
            serviceFuncionario.Update(funcionario);
        }
    }
}