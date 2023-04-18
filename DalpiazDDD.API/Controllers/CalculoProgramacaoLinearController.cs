using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DalpiazDDD.API.Controllers
{
    [Route("calculoprogramacaolinear/")]
    [ApiController]
    public class CalculoProgramacaoLinearController : Controller
    {
        private readonly IApplicationServiceCalculoProgramacaoLinear applicationServiceCalculoProgramacaoLinear;
        private readonly IApplicationServiceConjuntoEntrada applicationServiceConjuntoEntrada;


        public CalculoProgramacaoLinearController(
            IApplicationServiceCalculoProgramacaoLinear applicationServiceCalculoProgramacaoLinear,
            IApplicationServiceConjuntoEntrada applicationServiceConjuntoEntrada)
        {
            this.applicationServiceCalculoProgramacaoLinear = applicationServiceCalculoProgramacaoLinear;
            this.applicationServiceConjuntoEntrada = applicationServiceConjuntoEntrada;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var inicio = DateTime.Now;
            var conjuntoEntrada = applicationServiceConjuntoEntrada.GetByIdCompleto(id);
            applicationServiceCalculoProgramacaoLinear.Executar(conjuntoEntrada);
            var fim = DateTime.Now;
            var tempoTotal = fim.Subtract(inicio);
            return $"Início: {inicio}. Fim: {fim}. Tempo total da execução: {tempoTotal}.";
            return Ok();
        }
    }
}
