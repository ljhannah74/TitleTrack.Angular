using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TitleTrack.Server.Models;
using TitleTrack.Server.Repositories;

namespace TitleTrack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleAbstractController : ControllerBase
    {
        private readonly ITitleAbstractRepository _titleAbstractRepository;
        public TitleAbstractController(ITitleAbstractRepository titleAbstractRepository)
        {
            _titleAbstractRepository = titleAbstractRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleAbstract>>> GetAllTitleAbstractsAsync()
        {
            return Ok(await _titleAbstractRepository.GetAllTitleAbstractsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TitleAbstract>> GetTitleAbstractByIdAsync(int id)
        {
            var titleAbstract = await _titleAbstractRepository.GetTitleAbstractByIdAsync(id);
            if (titleAbstract == null)
            {
                return NotFound();
            }
            return Ok(titleAbstract);
        }

        [HttpPost]
        public async Task<ActionResult<TitleAbstract>> CreateTitleAbstractAsync([FromBody] TitleAbstract titleAbstract)
        {
            if (titleAbstract == null)
            {
                return BadRequest("Title abstract cannot be null.");
            }

            await _titleAbstractRepository.AddTitleAbstractAsync(titleAbstract);
            return CreatedAtAction(nameof(GetTitleAbstractByIdAsync), new { id = titleAbstract.TitleAbstractID }, titleAbstract);
        }
    }
}
