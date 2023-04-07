using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Domain.Enuns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DalpiazDDD.API.Controllers
{
    [Route("resultado/")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly IApplicationServiceConjuntoResultado applicationServiceConjuntoResultado;

        public ResultadoController(IApplicationServiceConjuntoResultado applicationServiceConjuntoResultado)
        {
            this.applicationServiceConjuntoResultado = applicationServiceConjuntoResultado;
        }

        // GET api/values
        [HttpGet("GetByEntrada")]
        public ActionResult<IEnumerable<ConjuntoResultadoDto>> GetByEntrada(int id)
        {
            return Ok(applicationServiceConjuntoResultado.ListarByEntrada(id));
        }

        // GET api/values
        [HttpGet("GetByResultadoTipo")]
        public ActionResult<dynamic> GetByResultadoTipo(int id, int tp)
        {
            return Ok(applicationServiceConjuntoResultado.LitarView(id,(TipoViewResultado) tp ));
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ConjuntoResultadoDto>> Get()
        {
            return Ok(applicationServiceConjuntoResultado.ResultadosSemListasInternas());
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ConjuntoResultadoDto> Get(int id)
        {
            return Ok(applicationServiceConjuntoResultado.Resultado(id));
        }
    }
}
