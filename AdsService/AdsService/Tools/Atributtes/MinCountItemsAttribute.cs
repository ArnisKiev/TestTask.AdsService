using DataBaseServises.Models;
using System.ComponentModel.DataAnnotations;

namespace AdsService.Tools.Atributtes
{
    public class MinCountItemsAttribute:ValidationAttribute
    {

        int _min;


      

        public MinCountItemsAttribute(int min)
        {
            _min = min;
        }

        public override bool IsValid(object? value)
        {
            if(value == null)
                return false;

            int count = (value as List<Photo>).Count;
            return count >= _min;

        }

    }
}
