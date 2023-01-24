using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class CompativelEquipamentoFp
    {
        public int IdTipoFp { get; set; }
        public int IdModeloFp { get; set; }
        public int IdTipoEquipamento { get; set; }
        public int IdModeloEquipamento { get; set; }
        public int QtdFp { get; set; }
    }
}
