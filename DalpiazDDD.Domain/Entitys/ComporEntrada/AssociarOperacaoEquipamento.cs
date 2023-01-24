using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class AssociarOperacaoEquipamento
    {
        public int Id { get; set; }
        public int IdOperacao { get; set; }
        public int IdTipoEquipamento { get; set; }
        public int IdModeloEquipamento { get; set; }
        public int IdEquipamento { get; set; }
    }
}
