using Newtonsoft.Json;
using System.IO;
using SymbolicLab2.Converters;

namespace SymbolicLab2.Reader
{
    class JsonExpressionReader : IExpressionReader
    {
        public Factor Read(string path)
        {
            var jsonTerm = JsonConvert.DeserializeObject<JsonTerm>(File.ReadAllText(path));
            var Factors =  Converter.JsonConvert(jsonTerm);
            return Factors;
        }
    }
}
