using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
    [DataContract]
    public class City
    {
        [DataMember(Name = "geonameId")]
        public string Id { get; set; }

        [DataMember(Name = "toponymName")]
        public string Name { get; set; }

        [DataMember(Name = "countrycode")]
        public string CountryCode { get; set; }

        [DataMember(Name = "wikipedia")]
        public string WikipediaUrl { get; set; }
        
        [DataMember(Name = "population")]
        public string Population { get; set; }

        [DataMember(Name = "lat")]
        public string Latitude { get; set; }

        [DataMember(Name = "lng")]
        public string Longitude { get; set; }

        public int Stars { get; set; }

    }
}
