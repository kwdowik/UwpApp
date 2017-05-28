using System.Collections.Generic;
using System.Threading.Tasks;
using UwpApp.DataAccess.Repositories;
using UwpApp.Models;

namespace UwpApp.Mocks
{
    public class MockCityRepository : IRepository<City>
    {
        public void Create(City item)
        {
        }

        public Task Create(List<City> items)
        {
            return null;
        }

        public City Read(string id)
        {
            return null;
        }

        public Task<List<City>> ReadAll()
        {
            return new Task<List<City>>(() => new List<City>());
        }

        public void Update(City item)
        {
        }

        public Task Update(List<City> item)
        {
            return null;
        }

        public void Delete(City item)
        {
        }

        public Task Delete(List<City> items)
        {
            return null;
        }
    }
}
