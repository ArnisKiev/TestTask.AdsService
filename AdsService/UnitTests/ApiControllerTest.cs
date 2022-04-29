using AdsService.Controllers;
using AdsService.Models;
using AdsService.Tools.Enums;
using DataBaseServises.Managers;
using DataBaseServises.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ApiControllerTest
    {

        AdsManager _dataStore;

        ApiController _sut;




        public ApiControllerTest()
        {
           _dataStore=A.Fake<AdsManager>();

        }




        [Fact]
        public async Task GetAds()
        {
            //Arrange

            var ads = A.CollectionOfDummy<AdResp>(0).ToList();
            
             A.CallTo(() =>  _dataStore.GetAdsAsync(0, TypeSortAds.NoSort, SortDirect.Asc)).Returns(ads);

            _sut=new ApiController(_dataStore);
            //Act
            var result = await _sut.GetAdsAsync();

            //Assert

            Assert.Equal(ads,result);
        }


        [Fact]
        public async Task GetAdById()
        {
            //Arrange

            Guid adId = Guid.NewGuid();
            AdResp adApi=new AdResp() { Id=adId};

           

            A.CallTo(() => _dataStore.GetAdById(adId)).Returns(adApi);

            _sut = new ApiController(_dataStore);
            
            //Act

            var result = await _sut.GetParticularAdAsync(adId, false);

            //Assert

            Assert.Equal<Guid>(adId,result.Value.Id);


        }

        [Fact]
        public async Task GetAdByIdOftFields()
        {
            //Arrange

            Guid adId = Guid.NewGuid();
            AdOptFieldsResp ad = new AdOptFieldsResp() { Id = adId };

            A.CallTo(() => _dataStore.GeAdByIdWithOptFields(adId)).Returns(ad);

            _sut = new ApiController(_dataStore);

            //Act

            var result =await _sut.GetParticularAdAsync(adId, true);

            //Assert


            var gotAd=result.Value ;
            Assert.IsType<AdOptFieldsResp>(gotAd);

        }

        [Fact]
        public async Task AddAd()
        {

            //Arrange


            Guid id = Guid.NewGuid();

            Ad ad = new Ad() { Id= id };

            A.CallTo(() => _dataStore.AddAdAsync(ad)).Returns((true,ad.Id));

            _sut = new ApiController(_dataStore);
            //Act
            var result = await _sut.AddAdAsync(ad);

            //Assert

            var returnedId = (result as OkObjectResult);
            Assert.Equal(id.ToString(), returnedId.Value.ToString());


        }

    }
}