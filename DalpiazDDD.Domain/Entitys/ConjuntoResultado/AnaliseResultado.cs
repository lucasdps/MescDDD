using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoResultado
{
    public class AnaliseResultado
    {
        public int Status { get; set; }
        public int ValorFuncaoObjetivo { get; set; }
        public int QtdVariaveis { get; set; }
        public int QtdRestricoes { get; set; }
        public int Iteracoes { get; set; }
        public int Nodes { get; set; }
        public int TempoMilisegundos { get; set; }
        public IList<AnaliseOperacao> u_o { get; set; }
        public IList<AnaliseOperacaoEquipamento> x { get; set; }
        public IList<AnaliseOperacaoFP> u_fp_o { get; set; }
        public IList<AnaliseOperacaoFS> u_fs_o { get; set; }
        public IList<AnaliseOperacaoEquipamentoFP> y { get; set; }
        public IList<AnaliseOperacaoEquipamentoFS> z { get; set; }
    }
}
