using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CharacterEpisodeService : ICharacterEpisodeService
    {
        private readonly ICharacterEpisodeRepository _characterEpisodeRepository;

        public CharacterEpisodeService(ICharacterEpisodeRepository characterEpisodeRepository)
        {
            _characterEpisodeRepository = characterEpisodeRepository;
        }

        public async Task<bool> AddEntity(CharacterEpisode entity)
        {
            return await _characterEpisodeRepository.Insert(entity);
        }

        public IEnumerable<CharacterEpisode> ReadAll()
        {
            return _characterEpisodeRepository.ReadAll();
        }

        public CharacterEpisode ReadOne(int id)
        {
            return _characterEpisodeRepository.ReadOne(id);
        }
    }
}
