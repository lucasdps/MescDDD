using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces
{
    public interface IApplicationServiceCalculoProgramacaoLinear
    {
        bool Executar(ConjuntoEntrada conjuntoEntrada);
    }
}
