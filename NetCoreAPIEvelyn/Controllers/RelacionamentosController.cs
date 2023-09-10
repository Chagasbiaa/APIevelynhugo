using Microsoft.AspNetCore.Mvc;
using NetCoreAPIEvelyn.Data.Repositories;
using NetCoreAPIEvelyn.Model;

namespace NetCoreAPIEvelyn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionamentosController : ControllerBase
    {

        private readonly IRelacionamentosRepository _relacionamentosRepository;

        public RelacionamentosController(IRelacionamentosRepository relacionamentosRepository)
        {
            _relacionamentosRepository = relacionamentosRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllRelacionamentos()

        {
            return Ok(await _relacionamentosRepository.GetRelacionamentos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelacionamentosDetail(int id)
        {
            return Ok(await _relacionamentosRepository.GetRelacionamentosDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRelacionamentos([FromBody] relacionamentos relacionamentos)
        {
            if (relacionamentos == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _relacionamentosRepository.InsertRelacionamentos(relacionamentos);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRelacionamentos([FromBody] relacionamentos relacionamentos)
        {
            if (relacionamentos == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _relacionamentosRepository.UpdateRelacionamentos(relacionamentos);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterelacionamentos(int id)
        {
            await _relacionamentosRepository.DeleteRelacionamentos(new relacionamentos() { idconjuge = id });
            return NoContent();
        }
    }
}
