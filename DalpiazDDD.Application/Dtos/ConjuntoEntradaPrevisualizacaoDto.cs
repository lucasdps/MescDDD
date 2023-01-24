using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Dtos
{
    public class ConjuntoEntradaPrevisualizacaoDto
    {
        public int Id { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public string Descricao { get; set; }
        public int QtdEquipamentos { get; set; }
        public int QtdOperacoes { get; set; }
        public int QtdFP { get; set; }
        public int QtdFS { get; set; }

    }
}
