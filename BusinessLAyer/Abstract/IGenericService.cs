using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T: class
    {
        Task<bool> AddEntity(T entity);
        IEnumerable<T> ReadAll();
        T ReadOne(int id);
    }
}
