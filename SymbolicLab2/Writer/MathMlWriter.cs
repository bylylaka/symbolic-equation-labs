using SymbolicLab2.Converters;
using SymbolicLab2.Writer.Models;
using System.IO;
using System.Xml.Serialization;

namespace SymbolicLab2.Writer
{
    public class MathMlWriter : IWriter
    {
        public void Write(Decomposed decomposed, string path)
        {
            var mathMlTerm = Converter.MathMLConvert(decomposed);

            var formatter = new XmlSerializer(typeof(MathMlTerm));

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fileStream, mathMlTerm);
            }
        }
    }
}
