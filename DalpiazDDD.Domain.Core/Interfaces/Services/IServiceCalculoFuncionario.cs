using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceCalculoFuncionario
    {
        CalculoFuncionario CalcularTotais(decimal montanteLucro);
    }
}
