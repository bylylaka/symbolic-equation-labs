using SymbolicLab2.Mappers;
using System.Linq;

namespace SymbolicLab2.Calculator
{
    public class GornersDividor : IDivider
    {
        public Factor Divide(Factor firstParam, int dividigNumberValue)
        {
            var maxPower = firstParam.Terms.Max(term => term.SymbolsPower);
            var dataTerms = new int[maxPower + 1];

            //initialize 0 if there is no x in such power
            firstParam.Terms.ForEach(term => dataTerms[term.SymbolsPower] = (term.Sign == Sign.Plus) ? term.Number : -term.Number);
            dataTerms = dataTerms.Reverse().ToArray();

            var newIndexes = new int[dataTerms.Count()];
            newIndexes[0] = dataTerms[0];

            for (int i = 1; i < newIndexes.Length; i++)
            {
                newIndexes[i] = dataTerms[i] - dividigNumberValue * newIndexes[i - 1];
            }

            if (newIndexes.Last() != 0)
            {
                return null;
            }

            var newTerms = newIndexes
                .Select((value, index) => Mapper.MapNumberToTerm(value, newIndexes.Length - index - 2))
                .Take(newIndexes.Length - 1);

            var newFactors = new Factor(newTerms.ToList());

            return newFactors;
        }
    }
}
