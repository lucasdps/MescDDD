using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys;

namespace DalpiazDDD.Domain.Services
{
    public class ServiceFuncionario : ServiceBase<Funcionario>, IServiceFuncionario
    {
        private readonly IRepositoryFuncionario repositoryFuncionario;

        public ServiceFuncionario(IRepositoryFuncionario repositoryFuncionario) : base(repositoryFuncionario)
        {
            this.repositoryFuncionario = repositoryFuncionario;
        }
    }
}