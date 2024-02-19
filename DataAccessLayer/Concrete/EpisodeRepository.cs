using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(KonusarakOgrenStajProjesiDbContext context) : base(context)
        {
        }
        public async Task<bool> DeleteAll()
        {
            return await _context.Database.ExecuteSqlRawAsync("DELETE from Episodes") > 0;
        }
    }
}
