using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DalpiazDDD.API.Controllers
{
    [Route("calculofuncionario/")]
    [ApiController]
    public class CalculoFuncionarioController : Controller
    {
        private readonly IApplicationServiceCalculoFuncionario applicationServiceCalculoFuncionario;


        public CalculoFuncionarioController(IApplicationServiceCalculoFuncionario applicationServiceCalculoFuncionario)
        {
            this.applicationServiceCalculoFuncionario = applicationServiceCalculoFuncionario;
        }
        // GET api/values
        [HttpGet("{montante}")]
        public ActionResult<IEnumerable<CalculoFuncionarioDto>> Get(string montante)
        {
            string valor = montante;
            // or i.e. string amount = "12,33";

            var c = System.Threading.Thread.CurrentThread.CurrentCulture;
            var s = c.NumberFormat.CurrencyDecimalSeparator;

            valor = valor.Replace(",", s);
            valor = valor.Replace(".", s);

            decimal valorConvertido = Convert.ToDecimal(valor);
            return Ok(applicationServiceCalculoFuncionario.CalculoFuncionarioPL(valorConvertido));
        }
    }
}
