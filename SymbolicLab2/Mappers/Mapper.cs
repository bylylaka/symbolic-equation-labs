using System;

namespace SymbolicLab2.Mappers
{
    public class Mapper
    {
        public static Term MapNumberToTerm(double number, int power)
        {
            var term = new Term
            {
                Number = Math.Abs(number),
                Sign = (number > 0) ? Sign.Plus : Sign.Minus,
                Symbol = (power > 0) ? 'x' : default(char),
                SymbolsPower = power
            };
            return term;
        }
    }
}
