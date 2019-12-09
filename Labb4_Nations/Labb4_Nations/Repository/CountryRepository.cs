using Labb4_Nations.Repository;
using System.Collections.Generic;

namespace Labb4_Nations
{
    class CountryRepository
    {
        private List<Country> countries;

        public List<Country> GetCountries()
        {
            return countries;
        }

        public CountryRepository()
        {
            ParseJson();
        }

        private void ParseJson()
        {
            JsonParser<CountryRepository> jsonParser = new JsonParser<CountryRepository>();
            jsonParser.Parse("rawData.json");
            countries = jsonParser.Type.countries;         
        }          
    }
}