
using AdsService.Models;
using AdsService.Tools.Enums;
using AdsService.Tools.Extansions;
using DataBaseServises.Models;
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
        PhotoRepository _photos;
        AdRepository _ads;
        
        public AdsManager()
        {
            _photos = new PhotoRepository();
            _ads = new AdRepository();
        }


       
       
        
        public virtual async Task<List<AdResp>> GetAdsAsync( int prevPage,TypeSortAds typeSort, SortDirect sortDirect)
        {

            var ads = await _ads.GetAllAsync();
            ads= ads.SortAdList(typeSort, sortDirect).Skip(10*prevPage).Take(10).ToList(); //SordAdList()- метод расширения, для сортировки списка объявлений  (Tools/Extansions/SortAdListExtansion)
            var mainPhotos = await GetMainPhotosAsync();

            return ads.Join(mainPhotos, ad => ad.Id, photo => photo.AdId,
                (ad, photo)=>
                new AdResp { Id=ad.Id, MainPhoto=photo.Img, Title=ad.Title, Price = ad.Price }).ToList();

        }

        public virtual async Task<AdResp> GetAdById(Guid id)
        {

            var ad=await _ads.GetByIdAsync(id);
            if(ad==null)
                return null;

            var mainPhoto = await  GetMainPhotosAsync().ContinueWith(photos=>photos.Result.FirstOrDefault(x => x.AdId == id));

            AdResp adResp =new AdResp()
            {
                Id=ad.Id,
                Title=ad.Title,
                Price=ad.Price,
                MainPhoto=mainPhoto.Img
            };

            return adResp;



        }


        public virtual async Task<AdOptFieldsResp> GeAdByIdWithOptFields(Guid id)
        {
            var ad = await _ads.GetByIdAsync(id);
            if (ad == null)
                return null;

            var mainPhoto = await GetMainPhotosAsync().ContinueWith(photos => photos.Result.FirstOrDefault(x => x.AdId == id));

            var optionalPhotos=await GetOtherPhotosByAdIdAsync(ad.Id).ContinueWith(photos=>photos.Result.Select(x=>x.Img).ToList());

            AdOptFieldsResp adResp = new AdOptFieldsResp() {
                Id = ad.Id,
                Title = ad.Title,
                Description = ad.Description,
                MainPhoto = mainPhoto.Img,
                Price = ad.Price,
                DateCreated = ad.DateCreated,
                OptionalPhotos = optionalPhotos
                

            };

                

            return adResp;
        }



        //список главных фотографий (первое добавленное фото пользователем)
        private async Task<List<Photo>> GetMainPhotosAsync()
        {
          var photos=await _photos.GetAllAsync();
            return photos.DistinctBy(x => x.AdId).ToList();
        }



        //фотографии объявления (не включает главное фото)
        private async Task<List<Photo>> GetOtherPhotosByAdIdAsync(Guid id)
        {

            var mainPhoto = await GetMainPhotosAsync().ContinueWith(photos=>photos.Result.FirstOrDefault(x=>x.AdId==id));
            var allPhotos=await _photos.GetAllAsync();

            return allPhotos.ToList().Where(x => x.AdId == id).Except(new List<Photo>() { mainPhoto }).ToList();
            

        }


        //если объявление добавленно в бд - возвращает true и Id добавленного объявления
        public virtual async Task<(bool, Guid)> AddAdAsync(Ad ad)
        {
            
            var photos=ad.Photos;
            ad.Photos = null;
            ad.DateCreated=DateTime.Now;

            var resp= await _ads.CreateAsync(ad);

            if (resp == null)
                return (false, Guid.Empty);

            for(int i = 0; i < photos.Count; i++)
            {
                var photo= photos[i];
                photo.AdId = resp.Id;
                await _photos.CreateAsync(photo);
            }
            await _ads.SaveChangesAsync();
            await _photos.SaveChangesAsync();

            return (true, resp.Id);



        }



    }
}
