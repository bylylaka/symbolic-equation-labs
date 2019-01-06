using System;
using System.Collections.Generic;
using System.Linq;

namespace SymbolicLab2.Calculator
{
    public class Factorizer : ICalculator, IFactorizer
    {
        public Decomposed Execute(Factor factors, IDivider divider)
        {
            factors = Normalize(factors);
            var decomposed = new Decomposed();

            decomposed.Factors.Add(factors);

            var continueFlag = true;

            while (continueFlag)
            {
                continueFlag = false;
                var freeTermFactors = GetNumberFactors(decomposed.Factors.Last().Terms.Where(x => x.SymbolsPower == 0).Select(term => term.Number).FirstOrDefault());

                freeTermFactors.ForEach(coefficent =>
                {
                    var dividedPart = divider.Divide(decomposed.Factors.Last(), -coefficent);

                    if (dividedPart != null)
                    {
                        var newdividerFactor = new Factor();
                        newdividerFactor.Terms = new List<Term>(){
                            new Term
                            {
                                Number = 1,
                                Sign = Sign.Plus,
                                Symbol = 'x',
                                SymbolsPower = 1
                            },
                            new Term
                            {
                                Number = Math.Abs(coefficent),
                                Sign = (coefficent >= 0) ? Sign.Minus : Sign.Plus,
                                SymbolsPower = 1
                            }
                        };

                        decomposed.Factors.Insert(0, newdividerFactor);
                        decomposed.Factors[decomposed.Factors.Count() - 1] = dividedPart;
                        continueFlag = true;
                    }
                });
            }
            return decomposed;
        }

        public Factor Normalize(Factor factors)
        {
            for (int i = 0; i < factors.Terms.Count; i++)
            {
                if (factors.Terms[i] == null)
                    break;

                for (int j = i + 1; j < factors.Terms.Count; j++)
                {
                    if (factors.Terms[i].SymbolsPower == factors.Terms[j].SymbolsPower)
                    {
                        factors.Terms[i].Number += factors.Terms[j].Number;
                        factors.Terms.RemoveAt(j);
                    }
                }
            }
            return factors;
        }

        public List<int> GetNumberFactors(int number)
        {
            var factors = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                    factors.Add(-i);
                }
            }
            return factors;
        }
    }
}
