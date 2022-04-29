using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        public void CreateOrUpdate(T item);
        public IList<T> GetItems(int page);
        public T GetItemById(Guid id);

    }
}
