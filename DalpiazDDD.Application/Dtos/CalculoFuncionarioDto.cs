namespace DalpiazDDD.Application.Dtos
{
    public class CalculoFuncionarioDto
    {
        public IEnumerable<FuncionarioDto> funcionariosDtos { get; set; }
        public decimal MontanteLucro { get; set; }
        public decimal TotalDisponibilizado { get; set; }
        public decimal TotalDistribuido { get; set; }
        public int TotalFuncionarios { get; set; }
        public decimal Saldo { get; set; }
    }
}