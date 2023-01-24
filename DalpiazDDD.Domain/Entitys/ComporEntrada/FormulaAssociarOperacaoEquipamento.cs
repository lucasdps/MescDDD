using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class FormulaAssociarOperacaoEquipamento
    {
        public int IdOperacao { get; set; }
        public int IdEquipamento { get; set; }
        public int Situacao { get; set; }
    }
}
