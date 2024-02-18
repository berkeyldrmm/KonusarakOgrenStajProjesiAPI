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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly KonusarakOgrenStajProjesiDbContext _context;

        public GenericRepository(KonusarakOgrenStajProjesiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(T entity)
        {
            var result = await _context.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadOne(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
