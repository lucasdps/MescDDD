using System.ComponentModel.DataAnnotations.Schema;

namespace DalpiazDDD.Domain.Entitys
{
    public class Funcionario
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public int AreaAtuacao { get; set; }
        public int Cargo { get; set; }
        public decimal SalarioBruto { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataCadastro { get; set; }
        [NotMapped]
        public decimal TotalPL { get; set; }
        [NotMapped]
        public decimal PorcentagemPL { get; set; }

        public int GetPesoFaixaSalarial()
        {
            if (SalarioBruto > 8 * CalculoFuncionario.SalarioMinimo)
            {
                return 5;
            }
            else if (SalarioBruto > 5 && SalarioBruto <= 8 * CalculoFuncionario.SalarioMinimo)
            {
                return 3;
            }
            else if (SalarioBruto > 3 && SalarioBruto <= 5 * CalculoFuncionario.SalarioMinimo)
            {
                return 2;
            }
            else
            {
                // SalarioBruto <= 3 * SalarioMinimo
                return 1;
            }
            
        }

        public int GetPesoPorTempoAdmissao()
        {
            TimeSpan tempoAdmissao = DateTime.Now.Subtract(DataAdmissao);
            int anos = (int)tempoAdmissao.TotalDays / 365;

            if (anos <= 1)
            {
                return 1;
            }
            else if (anos > 1 && anos <= 3)
            {
                return 2;
            }
            else if (anos > 3 && anos <= 8)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }


        public decimal GetPesoFormula()
        {
            return SalarioBruto > 0 ? (((SalarioBruto * GetPesoPorTempoAdmissao()) + (SalarioBruto * AreaAtuacao) )/ (SalarioBruto * GetPesoFaixaSalarial())) * 12 : 0;
        }
    }
}