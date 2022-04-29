using DataBaseServises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Repositories
{
    internal class PhotoRepository : IRepository<Photo>
    {
        public void CreateOrUpdate(Photo item)
        {
            throw new NotImplementedException();
        }

        public Photo GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Photo> GetItems(int page)
        {
            throw new NotImplementedException();
        }
    }
}
