using AdsService.Models;
using AdsService.Tools.Enums;
using DataBaseServises.Models;

namespace AdsService.Tools.Extansions
{
    public static class SortAdListExtansions
    {

        public static  IList<Ad> SortAdList(this IList<Ad> list, TypeSortAds typeSort, SortDirect direct)
        {


            switch (typeSort)
            {
                case TypeSortAds.SortByDate:
                    list=list.OrderBy(x => x.DateCreated).ToList();
                    break;
                      
                case TypeSortAds.SortByPrice:
                    list = list.OrderBy(x => x.Price).ToList();
                    break;               

            }

            if (direct == SortDirect.Desc)
                list=list.Reverse().ToList();

            return list;

        }

    }
}
