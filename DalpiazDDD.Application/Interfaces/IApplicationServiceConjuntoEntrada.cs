using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Interfaces
{
    public interface IApplicationServiceConjuntoEntrada 
    {
        void Add(ConjuntoEntradaCadastroDto conjuntoEntradaCadastroDto);
        void Update(ConjuntoEntradaDto conjuntoEntradaDto);
        void Remove(int id);
        IEnumerable<ConjuntoEntradaDto> GetAll();
        IEnumerable<ConjuntoEntradaPrevisualizacaoDto> GetAllPrevisualizacao();
        ConjuntoEntradaDto GetById(int id);
        ConjuntoEntrada GetByIdCompleto(int id);
        ConjuntoEntradaPrevisualizacaoDto GetByIdPrevisualizacao(int id);

    }
}
