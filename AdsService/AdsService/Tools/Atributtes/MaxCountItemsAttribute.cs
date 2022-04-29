using DataBaseServises.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AdsService.Tools.Atributes
{
    public class MaxCountItemsAttribute:ValidationAttribute
    {

        int _max;
        

     

        public MaxCountItemsAttribute(int max)
        {
            _max = max;
           
        }


        public override bool IsValid(object? value)
        {
           

            if (value == null )
                return false;

            var photos = (value as List<Photo>);

            if (photos.Count <= _max)
                return true;

            return false;



        }

    }
}
