using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using UwpApp.Models;

namespace UwpApp.Services
{
    public class DataProviderService : IDataProviderService<City>
    {
        private readonly  string URL_REQUEST = "http://api.geonames.org/citiesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&lang=de&username=demo";

        public City SelectedCity { get; set; }

        public async Task<List<City>> GetJson()
        {
            return await MakeRequest(URL_REQUEST);
        }

        public async Task DownloadImages(List<City> cities)
        {
            //foreach (var city in cities)
            //{
            //    await DownloadImage(City.Image, City.Name);
            //}
        }

        private async Task DownloadImage(string imageUri, string destination)
        {
            try
            {
                Uri source = new Uri(imageUri);
                StorageFolder destinationFolder= Package.Current.InstalledLocation;
                StorageFile destinationFile = await destinationFolder.CreateFileAsync(
                    destination+".jpg", CreationCollisionOption.GenerateUniqueName);

                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(source, destinationFile);
                await download.StartAsync();

            }
            catch (Exception ex)
            {
                Debug.Fail("Download Image Error", ex.Message);
            }
        }

        private async Task<List<City>> MakeRequest(string requestUrl)
        {
            try
            {
                var http = new HttpClient();
                var response = await http.GetAsync(requestUrl);
                if(response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(string.Format("Service error (HTTP {0}:",response.StatusCode));
                var result = await response.Content.ReadAsStringAsync();
                var serializer = new DataContractJsonSerializer(typeof(GeoNames));

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var data = serializer.ReadObject(ms);
                GeoNames jsonResponse = data as GeoNames;

                return jsonResponse?.Cities;
            }
            catch (Exception ex)
            {
                Debug.Fail("Cannot download json file.",ex.ToString());       
                return null;
            }

        }

    }

    [DataContract]
    internal class GeoNames
    {
        [DataMember(Name = "geonames")]
        public List<City> Cities { get; set; }
    }
}
