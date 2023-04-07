using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using DalpiazDDD.Domain.Enuns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryConjuntoResultado : IRepositoryBase<ConjuntoResultado>
    {
        DbSet<ConjuntoResultado> Contexto();

        dynamic LitarView(int idOperacao, TipoViewResultado tp);
    }
}
