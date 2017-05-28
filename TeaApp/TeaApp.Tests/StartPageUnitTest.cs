using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using UwpApp.DataAccess.Repositories;
using UwpApp.Mocks;
using UwpApp.Models;
using UwpApp.Services;

namespace UwpApp.Tests
{
    [TestClass]
    public class StartPageUnitTest
    {
        private IDataProviderService<City> _dataProviderService;
        private IRepository<City> _repository;


        [TestInitialize]
        public void Initialize()
        {
            _dataProviderService = new MockDataProviderService();
            _repository = new MockCityRepository();
        }

    }
}
