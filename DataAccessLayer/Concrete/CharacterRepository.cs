using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(KonusarakOgrenStajProjesiDbContext context) : base(context)
        {
        }

        public async Task<bool> DeleteAll()
        {
            return await _context.Database.ExecuteSqlRawAsync("DELETE from Characters") > 0;
        }
        
    }
}
