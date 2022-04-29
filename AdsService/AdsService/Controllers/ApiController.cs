using AdsService.Models;
using AdsService.Tools.Enums;
using DataBaseServises.Managers;
using DataBaseServises.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdsService.Controllers
{
    public class ApiController : Controller
    {

        AdsManager _manager;

        public ApiController(AdsManager adsManager)=>_manager = adsManager;

        public async Task<List<AdResp>> GetAdsAsync(int page=1, TypeSortAds typeSort=TypeSortAds.NoSort, SortDirect sortdirect=SortDirect.Asc) //typeSort- параметр сортировки: по дате,цене. sortDirect- по убыванию, возрастанию
        {

          return await _manager.GetAdsAsync( page-1,typeSort, sortdirect);

        }

        public async Task<ActionResult<AdResp>> GetParticularAdAsync(Guid id, bool fields=false)
        {
            return !fields? await _manager.GetAdById(id):await _manager.GeAdByIdWithOptFields(id);  //fields - в зависимости от значения, выводим дополнительные поля или нет


        }

        [HttpPost]
        public async Task<IActionResult> AddAdAsync(Ad ad)
        {
            if(ModelState.IsValid)
            {

                var res= await _manager.AddAdAsync(ad);

                if (res.Item1 == false) //item1- был ли добавлено объявление, или нет 
                    return BadRequest();

                return Ok(res.Item2); //item2 - ID созданого объявления

            }
            return BadRequest(StatusCode(400));

        }

        

    }
}
