using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoResultado
{
    public class AnaliseOperacaoEquipamentoFS
    {
        public int OperacaoId { get; set; }
        public int EquipamentoId { get; set; }
        public int FsId { get; set; }
        public int Realizada { get; set; }
    }
}
