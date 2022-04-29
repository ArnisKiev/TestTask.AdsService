using DataBaseServises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Repositories
{
    internal class AdRepository : IRepository<Ad>
    {
        public void CreateOrUpdate(Ad item)
        {
            throw new NotImplementedException();
        }

        public Ad GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Ad> GetItems(int page)
        {
            throw new NotImplementedException();
        }
    }
}
