using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Dtos
{
    public class AnaliseOperacaoFPDto
    {
        public int Id { get; set; }
        public int OperacaoId { get; set; }
        public int FpId { get; set; }
        public int Realizada { get; set; }

        public int ConjuntoResultadoId { get; set; }
    }
}
