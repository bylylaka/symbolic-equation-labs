using System.Collections.Generic;
using System.Linq;

namespace SymbolicLab2
{
    public class Decomposed
    {
        public List<Factor> Factors { get; set; }

        public Decomposed()
        {
            Factors = new List<Factor>();
        }

        public override string ToString()
        {
            var a = Factors.Select(factor => $"({factor.ToString()})");
            var factorString = string.Join(null, a);
            return factorString;
        }
    }
}
