using UwpApp.DataAccess.Repositories;
using UwpApp.Models;
using UwpApp.Services;
using UwpApp.ViewModels;

namespace UwpApp.Mocks
{
    public class MockStartPageViewModel : StartPageViewModel
    {
        public MockStartPageViewModel(IDataProviderService<City> dataProviderService, IRepository<City> repository) : base(dataProviderService, repository ,null)
        {

        }
        
    }
}
