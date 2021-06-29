using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste.Repository;

namespace teste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public testeContext _context { get; }
        public ValuesController(testeContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Evento.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            try
            {
                var result = await _context.Evento.FirstOrDefaultAsync( x => x.Id == id);

                return Ok(result);

            }
            catch(System.Exception)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
