using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceCalculoProgramacaoLinear
    {
        bool ExecutarOrTools(ConjuntoEntrada conjuntoEntrada);
    }
}
