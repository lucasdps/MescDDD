using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoResultado
{
    public class ConjuntoResultado
    {
        public int Id { get; set; }
        public AnaliseResultado AnaliseResultado { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }


        public int IdConjuntoEntrada { get; set; }
        public ConjuntoEntrada.ConjuntoEntrada ConjuntoEntrada { get; set; }
    }
}
