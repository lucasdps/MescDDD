using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class FS
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdCiclos { get; set; }
        public int IdTipoFs { get; set; }
        public int IdModeloFs { get; set; }
        public int IdTipoModeloFs { get; set; }
    }
}
