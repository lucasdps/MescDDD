using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;
using DalpiazDDD.Domain.Entitys.ConjuntoResultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Application.Dtos
{
    public class ConjuntoResultadoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }


        public int Status { get; set; }
        public int ValorFuncaoObjetivo { get; set; }
        public int QtdVariaveis { get; set; }
        public int QtdRestricoes { get; set; }
        public int Iteracoes { get; set; }
        public int Nodes { get; set; }
        public int TempoMilisegundos { get; set; }

        public IList<AnaliseOperacaoDto> u_o { get; set; }
        public IList<AnaliseOperacaoEquipamentoDto> x { get; set; }
        public IList<AnaliseOperacaoFPDto> u_fp_o { get; set; }
        public IList<AnaliseOperacaoFSDto> u_fs_o { get; set; }


        public int IdConjuntoEntrada { get; set; }
    }
}
