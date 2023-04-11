using DalpiazDDD.Domain.Entitys.ComporEntrada;
using DalpiazDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys.ConjuntoEntrada
{
    public class ConjuntoEntrada
    {
        public int Id { get; set; }
       // public Entrada Entrada { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        ////
        /// <summary>
        /// 
        /// </summary>

        public int QtdOperacoes { get; set; }
        public int QtdEquipamentos { get; set; }
        public int QtdFP { get; set; }
        public int QtdFS { get; set; }
        public int TotalTipoModeloEquipamento { get; set; }
        public int TotalTipoModeloFP { get; set; }
        public int TotalTipoModeloFS { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public IEnumerable<AssociarOperacaoEquipamento> AssociarOperacaoEquipamentos { get; set; }
        public IEnumerable<FormulaAssociarOperacaoEquipamento> ASS_OEs { get; set; }
        public IEnumerable<FormulaCompativelEquipamentoFpExtendido> ASS_EFPs { get; set; }
        public IEnumerable<FormulaCompativelFpFsExtendido> ASS_FPFSs { get; set; }
        public IEnumerable<CompativelEquipamentoFp> CompativelEquipamentosFps { get; set; }
        public IEnumerable<CompativelEquipamentoFpReduzido> CompativelEquipamentosFpReduzidos { get; set; }

        public IEnumerable<CompativelFpFs> CompativelFPsFSs { get; set; }
        public IEnumerable<CompativelFpFsReduzida> CompativelFPsFSReduzidas { get; set; }
        public IEnumerable<Equipamento> Equipamentos { get; set; }
        public IEnumerable<FP> FPs { get; set; }
        public IEnumerable<FS> FSs { get; set; }
        public IEnumerable<ManutencaoFP> ManutencaoFPs { get; set; }
        public IEnumerable<ManutencaoFS> ManutencaoFSs { get; set; }
        public IEnumerable<ModeloEquipamento> ModeloEquipamentos { get; set; }
        public IEnumerable<ModeloFP> ModeloFPs { get; set; }
        public IEnumerable<ModeloFS> ModeloFSs { get; set; }
        public IEnumerable<Operacao> Operacoes { get; set; }
        public IEnumerable<TipoEquipamento> TipoEquipamentos { get; set; }
        public IEnumerable<TipoModeloEquipamento> TipoModeloEquipamentos { get; set; }
        public IEnumerable<int> TM_EQ { get; set; }
        public IEnumerable<TipoFP> TipoFPs { get; set; }
        public IEnumerable<TipoModeloFP> TipoModeloFPs { get; set; }
        public IEnumerable<int> TM_FP { get; set; }
        public IEnumerable<TipoFS> TipoFSs { get; set; }
        public IEnumerable<TipoModeloFS> TipoModeloFSs { get; set; }
        public IEnumerable<int> TM_FS { get; set; }
        public IEnumerable<FormulaColisaoOperacao> COL_OPER { get; set; }
        public IEnumerable<FormulaColisaoOperacaoFP> COL_OPER_FP { get; set; }
        public IEnumerable<FormulaColisaoOperacaoFS> COL_OPER_FS { get; set; }
        public IEnumerable<FormulaCicloFP> CICLO_FP { get; set; }
        public IEnumerable<FormulaCicloFS> CICLO_FS { get; set; }





        public ICollection<ConjuntoResultado.ConjuntoResultado> ConjuntoResultados { get; set; }

    }
}
