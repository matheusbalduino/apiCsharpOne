using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste.Domain;
using teste.Repository;

namespace teste.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventoController: ControllerBase
    {
        private ItesteRepository _repo;

        public EventoController(ItesteRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEventoAsync(true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
        }
        
        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var results = await _repo.GetAllEventoAsyncById(eventoId, true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
        }

        [HttpGet("getByTema{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await _repo.GetAllEventoAsyncByTema(tema, true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
        }

        [HttpPost]
         public async Task<IActionResult> Post(Evento model)
        {
            try
            {
               _repo.Add(model);
            
                if(await _repo.saveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
            return BadRequest();
        }
        [HttpPut]
         public async Task<IActionResult> Put(int eventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetAllEventoAsyncById(eventoId,false);

                if(evento == null) return NotFound();

               _repo.Update(model);
            
                if(await _repo.saveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
            return BadRequest();
        }

        [HttpDelete]
         public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var evento = await _repo.GetAllEventoAsyncById(eventoId,false);

                if(evento == null) return NotFound();

               _repo.Delete(evento);
            
                if(await _repo.saveChangesAsync())
                {
                    return Ok();
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Sua requisição Falhou");
            }
            
            return BadRequest();
        }
    }
}