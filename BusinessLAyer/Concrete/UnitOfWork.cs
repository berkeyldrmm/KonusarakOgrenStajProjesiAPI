using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KonusarakOgrenStajProjesiDbContext _context;

        public UnitOfWork(KonusarakOgrenStajProjesiDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
