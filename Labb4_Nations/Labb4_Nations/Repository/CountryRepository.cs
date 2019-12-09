using System.Collections.Generic;

namespace Labb4_Nations
{
    class CountryRepository
    {
        public List<Country> Countries {get; set;}
        private JsonParser<CountryRepository> jsonParser;

        public List<Country> GetCountries()
        {
            ParseJson();
            return Countries;
        }

        public CountryRepository()
        {
            jsonParser = new JsonParser<CountryRepository>();            
        }

        private void ParseJson()
        {           
            jsonParser.Parse("rawData.json");
            Countries = jsonParser.Type.Countries;            
        }          
    }
}