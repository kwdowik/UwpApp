using UwpApp.Models;
using UwpApp.Services;
using UwpApp.ViewModels;

namespace UwpApp.Mocks
{
    public class MockDetailsPageViewModel : DetailsPageViewModel
    {
        public MockDetailsPageViewModel(IDataProviderService<City> dataProviderService) : base(dataProviderService, null, null)
        {   
        }
        
    }
}
