using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoEquipamento { get; set; }
        public int IdModeloEquipamento { get; set; }
        public int IdTipoModeloEquipamento { get; set; }
    }
}
