using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Services
{
    public class ServiceCalculoFuncionario : ServiceFuncionario, IServiceCalculoFuncionario
    {
        private readonly IRepositoryFuncionario repositoryFuncionario;
        public ServiceCalculoFuncionario(IRepositoryFuncionario repositoryFuncionario) : base(repositoryFuncionario)
        {
            this.repositoryFuncionario = repositoryFuncionario;
        }

        public CalculoFuncionario CalcularTotais(decimal montanteLucro)
        {
            var funcionarios = this.repositoryFuncionario.GetAll().ToList();
            return new CalculoFuncionario(montanteLucro,funcionarios);
        }
    }
}
