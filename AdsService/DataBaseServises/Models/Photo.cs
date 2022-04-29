using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Models
{
    public class Photo
    {
        public Guid? Id { get; set; }

        public string Img { get; set; }
        public bool IsMain { get; set; }

        public virtual Guid? AdId { get; set; }



    }
}
