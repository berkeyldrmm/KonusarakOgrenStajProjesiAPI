using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task<bool> AddEntity(Episode entity)
        {
            return await _episodeRepository.Insert(entity);
        }

        public IEnumerable<Episode> ReadAll()
        {
            return _episodeRepository.ReadAll();
        }

        public Episode ReadOne(int id)
        {
            return _episodeRepository.ReadOne(id);
        }
        public async Task<bool> DeleteAll()
        {
            return await _episodeRepository.DeleteAll();
        }
    }
}
