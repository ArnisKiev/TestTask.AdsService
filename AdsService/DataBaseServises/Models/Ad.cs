using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Models
{
    public class Ad
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IList<Photo> Photos { get; set; }

        public Ad()=>Photos= new List<Photo>();



    }
}
