using System.Collections.Generic;
using System.Threading.Tasks;
using UwpApp.Models;

namespace UwpApp.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        void Create(T item);

        Task Create(List<T> items);

        T Read(string id);

        Task<List<City>> ReadAll();

        void Update(T item);

        Task Update(List<T> item);

        void Delete(T item);

        Task Delete(List<T> items);

    }
}
