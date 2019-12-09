using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Labb4_Nations.Repository
{
    public class JsonParser<T>
    {
       public T Type { get; set; } 

       public void Parse(string json)
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{json}");
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                Type = JsonConvert.DeserializeObject<T>(jsonString);
            }            
        }
    }
}

