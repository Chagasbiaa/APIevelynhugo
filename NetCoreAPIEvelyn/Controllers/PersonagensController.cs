using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIEvelyn.Data.Repositories;
using NetCoreAPIEvelyn.Model;

namespace NetCoreAPIEvelyn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {

        private readonly IPersonagensRepository _personagensRepository;

        public PersonagensController(IPersonagensRepository personagensRepository)
        {
            _personagensRepository = personagensRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonagens()
        {
            return Ok(await _personagensRepository.GetAllPersonagens());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonagensDetail(int id)
        {
            return Ok(await _personagensRepository.GetPersonagensDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonagens([FromBody] personagens personagem )
        {
            if (personagem == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personagensRepository.InsertPersonagens(personagem);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonagens([FromBody] personagens personagem)
        {
            if (personagem == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personagensRepository.UpdatePersonagens(personagem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Deletepersonagens(int id)
        {
            await _personagensRepository.DeletePersonagens(new personagens() { idpersona = id });
            return NoContent(); 
        }
    }
}
