using DataBaseServises.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Managers
{
    public class AdsManager
    {
        private AdRepository _adRepository;
        private PhotoRepository _photoRepository;

        public AdsManager()
        {
            _adRepository = new AdRepository();
            _photoRepository = new PhotoRepository();
        }
        
    }
}
