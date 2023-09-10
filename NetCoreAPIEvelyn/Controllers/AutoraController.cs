using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIEvelyn.Data.Repositories;
using NetCoreAPIEvelyn.Model;

namespace NetCoreAPIEvelyn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoraController : ControllerBase
    {
   
            private readonly IAutoraRepository _autoraRepository;

            public AutoraController(IAutoraRepository autoraRepository)
            {
                _autoraRepository = autoraRepository;

            }
            [HttpGet]
            public async Task<IActionResult> GetAllAutora()
            {
                return Ok(await _autoraRepository.GetAllAutora());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetAutoraDetail(int id)
            {
                return Ok(await _autoraRepository.GetAutoraDetails(id));
            }

            [HttpPost]
            public async Task<IActionResult> CreateaAutora([FromBody] autora autora)
            {
                if (autora == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var created = await _autoraRepository.InsertAutora(autora);
                return Created("created", created);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateAutora([FromBody] autora autora)
            {
                if (autora == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _autoraRepository.UpdateAutora(autora);

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Deleteautora(int id)
            {
                await _autoraRepository.DeleteAutora(new autora() { idautora = id });
                return NoContent();
            }
        }
    }
