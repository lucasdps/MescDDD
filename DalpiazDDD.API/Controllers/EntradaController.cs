using DalpiazDDD.Application;
using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DalpiazDDD.API.Controllers
{
    [Route("entrada/")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IApplicationServiceConjuntoEntrada applicationServiceConjuntoEntrada;

        public EntradaController(IApplicationServiceConjuntoEntrada applicationServiceConjuntoEntrada)
        {
            this.applicationServiceConjuntoEntrada = applicationServiceConjuntoEntrada;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceConjuntoEntrada.GetAllPrevisualizacao());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceConjuntoEntrada.GetByIdPrevisualizacao(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ConjuntoEntradaCadastroDto conjuntoEntradaCadastroDto)
        {
            try
            {
                if (conjuntoEntradaCadastroDto == null)
                    return NotFound();

                applicationServiceConjuntoEntrada.Add(conjuntoEntradaCadastroDto);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ConjuntoEntradaDto conjuntoEntradaDto)
        {
            try
            {
                if (conjuntoEntradaDto == null)
                    return NotFound();

                applicationServiceConjuntoEntrada.Update(conjuntoEntradaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceConjuntoEntrada.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
