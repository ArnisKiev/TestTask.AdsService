using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Repositories
{
     interface IRepository<T>
    {
        public Task<T> CreateAsync(T item);
        public void Update(T item);
        public void Remove(T item);
        public Task<IList<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task SaveChangesAsync();
    }
}
