using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoResultado
{
    public class AnaliseResultado
    {
       
        public IList<AnaliseOperacao> u_o { get; set; }
        public IList<AnaliseOperacaoEquipamento> x { get; set; }
        public IList<AnaliseOperacaoFP> u_fp_o { get; set; }
        public IList<AnaliseOperacaoFS> u_fs_o { get; set; }
        public IList<AnaliseOperacaoEquipamentoFP> y { get; set; }
        public IList<AnaliseOperacaoEquipamentoFS> z { get; set; }
    }
}
