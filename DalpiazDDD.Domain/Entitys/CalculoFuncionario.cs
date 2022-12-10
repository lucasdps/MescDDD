using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Domain.Entitys
{
    public class CalculoFuncionario
    {
        public static decimal SalarioMinimo = 1000;
        public decimal MontanteLucro { get; set; }
        public decimal TotalDisponibilizado { get; set; }
        public decimal TotalDistribuido { get; set; }
        public int TotalFuncionarios { get; set; }
        public decimal Saldo { get; set; }

        public IList<Funcionario> funcionarios { get; set; }

        public CalculoFuncionario(decimal montanteLucro, IList<Funcionario> funcionarios)
        {
            MontanteLucro = montanteLucro;
            this.funcionarios = funcionarios;
            this.TotalFuncionarios = funcionarios.Count;
            CalcularPLParaTodos();
        }

        public void CalcularPLParaTodos()
        {
            var somatorioTotalPesos = this.funcionarios.Sum(f => f.GetPesoFormula());
            this.funcionarios.ToList().ForEach(item => {
                item.PorcentagemPL = (item.GetPesoFormula() / somatorioTotalPesos);
                item.TotalPL = MontanteLucro * item.PorcentagemPL;
                item.TotalPL = Math.Round((decimal)item.TotalPL, 2); 
            });

            this.TotalDisponibilizado = this.MontanteLucro;
            this.TotalDistribuido = this.funcionarios.Sum(f=>f.TotalPL);
            this.Saldo = this.TotalDisponibilizado - this.TotalDistribuido;

        }

       
    }
}
