using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoResultado
{
    public class AnaliseOperacaoEquipamento
    {
        public int Id { get; set; }
        public int OperacaoId { get; set; }
        public int EquipamentoId { get; set; }
        public int Realizada { get; set; }

        public int ConjuntoResultadoId { get; set; }
        public ConjuntoResultado ConjuntoResultado { get; set; }
    }
}
