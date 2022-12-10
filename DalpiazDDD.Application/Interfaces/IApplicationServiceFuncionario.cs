using DalpiazDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces
{
    public interface IApplicationServiceFuncionario
    {
        void Add(FuncionarioDto funcionarioDto);
        void Update(FuncionarioDto funcionarioDto);
        void Remove(int id);
        IEnumerable<FuncionarioDto> GetAll();
        FuncionarioDto GetById(int id);
    }
}
