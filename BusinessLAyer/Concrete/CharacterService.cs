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
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<bool> AddEntity(Character entity)
        {
            return await _characterRepository.Insert(entity);
        }

        public IEnumerable<Character> ReadAll()
        {
            return _characterRepository.ReadAll();
        }

        public Character ReadOne(int id)
        {
            return _characterRepository.ReadOne(id);
        }

        public async Task<bool> DeleteAll()
        {
            return await _characterRepository.DeleteAll();
        }
    }
}
