using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoEntrada
{
    public class ConjuntoEntrada
    {
        public int Id { get; set; }
        public Entrada Entrada { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<ConjuntoResultado.ConjuntoResultado> ConjuntoResultados { get; set; }

    }
}
