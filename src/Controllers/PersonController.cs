using Microsoft.AspNetCore.Mvc;
using Apizinha.src.Models;
using Apizinha.src.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace Apizinha.src.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PersonController : Controller
    {
        private DataBaseContext _context { get; set; }

        public PersonController(DataBaseContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetPerson()
        {
            //Person pessoa = new Person("Anderson",21,"20200700829");
            //Contract NewContrato = new Contract("010203",27.9);
            var result = _context.Pessoas.Include(p => p.contratos).ToList();
            if (!result.Any()) return NoContent();
            return Ok(result);
            
        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody]Person pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception)
            {

               return BadRequest(new
               {msg = "Não foi criado",
               status = HttpStatusCode.BadRequest} );
            }
            
            return Created("Criado",pessoa);
        }

        [HttpPut("{id}")]
        public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person pessoa)
        {
            var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
            if (result is null)
            {
                return NotFound(new
                {msg = "Registro não existe", 
                status = HttpStatusCode.NotFound
                } );
            }
                try
            {
                _context.Pessoas.Update(pessoa);
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest(new
                {
                    msg = $"Dados pessoa id {id} não atualizado!",
                    status = HttpStatusCode.BadRequest
                });
            }

            return Ok(new
            {
                msg = $"Id:{id} atualizados",
                status = HttpStatusCode.OK
            });
        }
        [HttpDelete("{id}")]
        public ActionResult<Object> Delete([FromRoute]int id)
        {
            var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
            if (result is null)
            {
                return BadRequest(new
                {msg = "Conteúdo inexistente, solicitação inválida!", 
                status = HttpStatusCode.BadRequest});
            }
            _context.Pessoas.Remove(result);
            _context.SaveChanges();
            return Ok(new
            {
                msg = "Deletado pessoa de id:" + id,
                status = HttpStatusCode.OK
            } );
        }
    }
}
        