using BusinessLayer.Abstract;
using DataAccessLayer;
using KonusarakOgrenStajProjesiAPI.Authentication;
using KonusarakOgrenStajProjesiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KonusarakOgrenStajProjesiAPI.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyApiController : ControllerBase
    {
        private readonly IApiService _apiService;
        private readonly ICharacterService _characterService;
        private readonly IEpisodeService _episodeService;
        private readonly ICharacterEpisodeService _characterEpisodeService;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public ApplyApiController(ICharacterService characterService, IEpisodeService episodeService, IConfiguration configuration, IUnitOfWork unitOfWork, IApiService apiService, ICharacterEpisodeService characterEpisodeService)
        {
            _characterService = characterService;
            _episodeService = episodeService;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _apiService = apiService;
            _characterEpisodeService = characterEpisodeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string episodesJson = await _apiService.Get(_configuration["APIUrls:Episode"]);
            EpisodesModel episodes = JsonConvert.DeserializeObject<EpisodesModel>(episodesJson);

            string charactersJson = await _apiService.Get(_configuration["APIUrls:Character"]);
            CharactersModel characters = JsonConvert.DeserializeObject<CharactersModel>(charactersJson);

            if (characters is not null && episodes is not null)
            {

                while(true)
                {
                    foreach (var characterModel in characters.Results)
                    {
                        Character c = new Character()
                        {
                            Id = characterModel.Id,
                            Name = characterModel.Name,
                            Created = characterModel.Created,
                            Gender = characterModel.Gender,
                            Image = characterModel.Image,
                            Location = JsonConvert.SerializeObject(characterModel.Location),
                            Origin = JsonConvert.SerializeObject(characterModel.Origin),
                            Species = characterModel.Species,
                            Status = characterModel.Status,
                            Type = characterModel.Type,
                            Url = characterModel.Url
                        };
                        if (!await _characterService.AddEntity(c))
                        {
                            throw new Exception("Bir hata oluştu. Karakterler eklenemedi.");
                        }
                    }

                    if (characters.Info.Next != null)
                    {
                        charactersJson = await _apiService.Get(characters.Info.Next);
                        characters = JsonConvert.DeserializeObject<CharactersModel>(charactersJson);
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    foreach (var episodeModel in episodes.Results)
                    {
                        Episode e = new Episode()
                        {
                            Id = episodeModel.Id,
                            Name = episodeModel.Name,
                            AirDate = episodeModel.AirDate,
                            Created = episodeModel.Created,
                            Episode1 = episodeModel.Episode,
                            Url = episodeModel.Url
                        };
                        if (!await _episodeService.AddEntity(e))
                        {
                            throw new Exception("Bir hata oluştu. Bölümler eklenemedi.");
                        }

                        foreach (var characterUri in episodeModel.Characters)
                        {
                            string[] uriParts = characterUri.Split("/");
                            string idString = uriParts[uriParts.Length-1];
                            int id = Convert.ToInt32(idString);

                            CharacterEpisode ce = new CharacterEpisode()
                            {
                                EpisodeId = e.Id,
                                Episode = e,
                                CharacterId = id,
                                Character = _characterService.ReadOne(id)
                            };

                            if (!await _characterEpisodeService.AddEntity(ce))
                            {
                                throw new Exception("Bir hata oluştu. Bölümler eklenemedi.");
                            }
                        }
                    }

                    if (episodes.Info.Next != null)
                    {
                        episodesJson = await _apiService.Get(episodes.Info.Next);
                        episodes = JsonConvert.DeserializeObject<EpisodesModel>(episodesJson);
                    }
                    else
                    {
                        break;
                    }
                }

                await _unitOfWork.SaveChanges();
                return Ok();
            }

            throw new Exception("Bir hata oluştu.");
        }
    }
}
