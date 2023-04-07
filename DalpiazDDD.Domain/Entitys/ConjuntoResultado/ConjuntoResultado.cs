using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoResultado
{
    public class ConjuntoResultado
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }


        public int Status { get; set; }
        public int ValorFuncaoObjetivo { get; set; }
        public int QtdVariaveis { get; set; }
        public int QtdRestricoes { get; set; }
        public int Iteracoes { get; set; }
        public int Nodes { get; set; }
        public int TempoMilisegundos { get; set; }

        public ICollection<AnaliseOperacao> u_o { get; set; }
        public ICollection<AnaliseOperacaoEquipamento> x { get; set; }
        public ICollection<AnaliseOperacaoFP> u_fp_o { get; set; }
        public ICollection<AnaliseOperacaoFS> u_fs_o { get; set; }
        //public ICollection<AnaliseOperacaoEquipamentoFP> y { get; set; }
        //public ICollection<AnaliseOperacaoEquipamentoFS> z { get; set; }


        public int IdConjuntoEntrada { get; set; }
        public ConjuntoEntrada.ConjuntoEntrada ConjuntoEntrada { get; set; }
    }
}
