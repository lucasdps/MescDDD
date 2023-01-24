using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class FP
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdCiclos { get; set; }
        public int IdTipoFp { get; set; }
        public int IdModeloFp { get; set; }
        public int IdTipoModeloFp { get; set; }
    }
}
