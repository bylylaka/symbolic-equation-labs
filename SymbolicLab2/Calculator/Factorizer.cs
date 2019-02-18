using SymbolicLab2.Calculator.NumberFactor;
using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SymbolicLab2.Calculator
{
    public class Factorizer : ICalculator, IFactorizer
    {
        public Decomposed Execute(
            Factor factors,
            IDivider divider,
            dynamic algorithm,
            IUserAlgorithmStrategyProvider strategtProvider
        )
        {
            factors = Normalize(factors);
            var decomposed = new Decomposed();

            decomposed.Factors.Add(factors);

            var continueFlag = true;

            while (continueFlag)
            {
                continueFlag = false;
                var freeTermFactors = (List<int>)GetNumberFactors(decomposed.Factors.Last().Terms.Where(x => x.SymbolsPower == 0).Select(term => term.Number).FirstOrDefault(),
                    algorithm,
                    strategtProvider
                );

                freeTermFactors.ForEach(coefficent =>
                {
                    var dividedPart = divider.Divide(decomposed.Factors.Last(), -coefficent);

                    if (dividedPart != null)
                    {
                        Console.WriteLine(decomposed);

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

        public List<int> GetNumberFactors(
            double number,
            dynamic algorithm,
            IUserAlgorithmStrategyProvider strategtProvider
        )
        {
            var store = new UserAlgorithmStore();
            var numberFactorsExecutor = new NumberFactorsCalculator();

            var numbers = (List<double>)numberFactorsExecutor.GetNumberFactors((int)number, algorithm, strategtProvider, store);
            var result = numbers.Select(x => (int)x).ToList();

            return result;
        }
    }
}
