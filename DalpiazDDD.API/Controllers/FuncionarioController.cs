using Microsoft.AspNetCore.Mvc;
using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace DalpiazDDD.API.Controllers
{
    [Route("funcionario/")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IApplicationServiceFuncionario applicationServiceFuncionario;


        public FuncionarioController(IApplicationServiceFuncionario applicationServiceFuncionario)
        {
            this.applicationServiceFuncionario = applicationServiceFuncionario;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceFuncionario.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceFuncionario.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] FuncionarioDto funcionarioDTO)
        {
            try
            {
                if (funcionarioDTO == null)
                    return NotFound();

                applicationServiceFuncionario.Add(funcionarioDTO);
                return Ok("Funcionario Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] FuncionarioDto funcionarioDTO)
        {
            try
            {
                if (funcionarioDTO == null)
                    return NotFound();
               
                applicationServiceFuncionario.Update(funcionarioDTO);
                return Ok("Funcionario Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                applicationServiceFuncionario.Remove(id);
                return Ok("Funcionario Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}