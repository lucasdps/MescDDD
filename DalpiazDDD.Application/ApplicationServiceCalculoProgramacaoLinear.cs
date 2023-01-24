using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application
{
    public class ApplicationServiceCalculoProgramacaoLinear : IApplicationServiceCalculoProgramacaoLinear
    {
        private readonly IServiceCalculoProgramacaoLinear serviceCalculoProgramacaoLinear;

        public ApplicationServiceCalculoProgramacaoLinear(IServiceCalculoProgramacaoLinear serviceCalculoProgramacaoLinear)
        {
            this.serviceCalculoProgramacaoLinear = serviceCalculoProgramacaoLinear;
        }

        public bool Executar(ConjuntoEntrada conjuntoEntrada)
        {
           return this.serviceCalculoProgramacaoLinear.ExecutarOrTools(conjuntoEntrada);
        }
    }
}
