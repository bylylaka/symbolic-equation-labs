using System;
using System.Collections.Generic;
using System.Linq;

namespace SymbolicLab2
{
    public class Factor
    {
        public List<Term> Terms { get; set; }

        public Factor()
        {
            Terms = new List<Term>();
        }

        public Factor(List<Term> terms)
        {
            Terms = terms;
        }

        public static Factor operator +(Factor firstParam, Factor secondParam)
        {
            var newTerms = firstParam.Terms.Union(secondParam.Terms);
            return new Factor(newTerms.ToList());
        }

        public static Factor operator -(Factor firstParam, Factor secondParam)
        {
            secondParam.Terms = secondParam.Terms.Select(secondTerm =>
            {
                secondTerm.Sign = (secondTerm.Sign == Sign.Minus) ? Sign.Plus : Sign.Minus;
                return secondTerm;
            })
            .ToList();

            return firstParam + secondParam;
        }

        public static Factor operator *(Factor firstParam, Factor secondParam)
        {
            var newTerms = new List<Term>();

            firstParam.Terms.ForEach(firstTerm =>
            {
                secondParam.Terms.ForEach(secondTerm =>
                {
                    newTerms.Add(new Term
                    {
                        Number = firstTerm.Number * secondTerm.Number,
                        Sign = (firstTerm.Sign == secondTerm.Sign) ? Sign.Plus : Sign.Minus,
                        Symbol = (firstTerm.Symbol != null) ? firstTerm.Symbol : secondTerm.Symbol,
                        SymbolsPower = firstTerm.SymbolsPower + secondTerm.SymbolsPower
                    });
                });
            });

            return new Factor(newTerms);
        }

        public static Factor operator ^(Factor firstParam, Factor secondParam)
        {
            var newTerms = firstParam.Terms.Select(firstTerm =>
            {
                return new Term
                {
                    Number = (int)Math.Pow(firstTerm.Number, secondParam.Terms.First().Number),
                    Sign = firstTerm.Sign,
                    Symbol = firstTerm.Symbol,
                    SymbolsPower = firstTerm.SymbolsPower * secondParam.Terms.First().Number
                };
            });

            return new Factor(newTerms.ToList());
        }

        public override string ToString()
        {
            var a = Terms.Select(term => term.ToString());
            var factorString = string.Join(null, a);
            return factorString;
        }
    }
}
