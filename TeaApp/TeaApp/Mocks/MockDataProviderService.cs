using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UwpApp.Models;
using UwpApp.Services;

namespace UwpApp.Mocks
{
    public class MockDataProviderService : IDataProviderService<City>
    {
        public MockDataProviderService()
        {
            SelectedCity = new City
            {
                Id = "0",
                Latitude = "0",
                Longitude = "0",
                Name = string.Empty,
                Population = "0",
                WikipediaUrl = string.Empty
            };
        }

        public City SelectedCity { get; set; }

        public Task<List<City>> GetJson()
        {
            return null;
        }

        public Task DownloadImages(List<City> cities)
        {
            return null;
        }
    }
}
