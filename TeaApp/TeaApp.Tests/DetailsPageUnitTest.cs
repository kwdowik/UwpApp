using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using UwpApp.Mocks;
using UwpApp.Models;
using UwpApp.Services;

namespace UwpApp.Tests
{
    [TestClass]
    public class DetailsPageUnitTest
    {

        private IDataProviderService<City> _dataProviderService;

        [TestInitialize]
        public void Initialize()
        {
            _dataProviderService = new MockDataProviderService();
        }

        [TestMethod]
        public void TappedAction_ReviewCity_Reviewed()
        {
            //arrange                  
            var page = new MockDetailsPageViewModel(_dataProviderService);

            //act
            page.StarsValue = 3;

            //assert
            int expectedValue = 3;
            Assert.AreEqual(expectedValue, page.StarsValue);
        }

        [TestMethod]
        public void TappedAction_ReviewCity_SelectedCityUpdated()
        {
            //arrange
            var page = new MockDetailsPageViewModel(_dataProviderService);

            //act
            page.StarsValue = 3;

            //assert
            int expectedValue = 3;
            Assert.AreEqual(expectedValue, page.SelectedCity.Stars);
        }

    }
}
