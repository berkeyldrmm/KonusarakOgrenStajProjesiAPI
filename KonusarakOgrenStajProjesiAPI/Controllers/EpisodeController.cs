using BusinessLayer.Abstract;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgrenStajProjesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet]
        public IActionResult GetEpisodes()
        {
            IEnumerable<Episode> episodes = _episodeService.ReadAll();
            if (episodes is not null)
            {
                return Ok(episodes);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEpisode(int id)
        {
            Episode episode = _episodeService.ReadOne(id);
            if (episode is not null)
            {
                return Ok(episode);
            }
            return NotFound();
        }

        //[HttpPost]
        //public IActionResult PostCharacter(CharacterModel characterModel)
        //{
        //    Character character = new Character()
        //    {
        //        Id = Guid.NewGuid().ToString() + DateTime.Now.ToString("hhmmss"),
        //    }
        //}

        [HttpDelete]
        public async Task<IActionResult> DeleteEpisodes()
        {
            if (await _episodeService.DeleteAll())
            {
                return NoContent();
            }
            throw new Exception("Bölümler silinemedi.");
        }
    }
}
