using Newtonsoft.Json;
using System.IO;

namespace SymbolicLab2.Reader
{
    class JsonAlgorithmReader : IAlgorithmReader
    {
        public dynamic Read(string path)
        {
            var algorithm = JsonConvert.DeserializeObject<object>(File.ReadAllText(path));
            return algorithm;
        }
    }
}
