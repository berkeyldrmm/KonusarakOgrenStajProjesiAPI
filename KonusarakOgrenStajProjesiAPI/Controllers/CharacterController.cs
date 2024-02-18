﻿using BusinessLayer.Abstract;
using DataAccessLayer;
using KonusarakOgrenStajProjesiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgrenStajProjesiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public IActionResult GetCharacters()
        {
            IEnumerable<Character> charachters = _characterService.ReadAll();
            if (charachters is not null)
            {
                return Ok(charachters);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetCharacter(int id)
        {
            Character charachter = _characterService.ReadOne(id);
            if (charachter is not null)
            {
                return Ok(charachter);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult PostCharacter(CharacterModel characterModel)
        {
            Character character = new Character()
            {
                Id = Guid.NewGuid().ToString() + DateTime.Now.ToString("hhmmss"),
            }
        }
    }
}
