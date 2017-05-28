using System.Collections.Generic;
using System.Threading.Tasks;
using UwpApp.Models;

namespace UwpApp.Services
{
    public interface IDataProviderService<T>
    {
        T SelectedCity { get; set; }
        Task<List<T>> GetJson();
        Task DownloadImages(List<City> cities);
    }
}
