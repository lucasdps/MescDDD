using DalpiazDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces
{
    public interface IApplicationServiceCalculoFuncionario
    {
        CalculoFuncionarioDto CalculoFuncionarioPL(decimal montanteLucro);
    }
}
