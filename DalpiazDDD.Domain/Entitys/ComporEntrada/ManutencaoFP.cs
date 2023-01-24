using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ComporEntrada
{
    public class ManutencaoFP
    {
        public int Id { get; set; }
        public int DataIni { get; set; }
        public int DataFim { get; set; }
        public int IdFp { get; set; }
    }
}
