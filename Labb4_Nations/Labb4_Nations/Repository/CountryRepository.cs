using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace Labb4_Nations
{
    class CountryRepository
    {
        private CountryList countries;
       
        public CountryRepository()
        {
            GetJsonData();
        }

        public List<Country> GetCountries() {
            return countries.Countries;
        }

        private void GetJsonData()
        {
            string jsonFileName = "rawData.json";
            
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();            
                countries = JsonConvert.DeserializeObject<CountryList>(jsonString);
            }          
        }

        private class CountryList
        {
            public List<Country> Countries { get; set; }
        }
    }
}