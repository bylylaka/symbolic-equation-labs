using SymbolicLab2.Reader;
using SymbolicLab2.Writer.Models;
using System;
using System.Collections.Generic;

namespace SymbolicLab2.Converters
{
    public static class Converter
    {
        public static Factor JsonConvert(JsonTerm jsonTerm, List<Term> terms = null)
        {
            if (jsonTerm.Operation != Operation.Empty)
            {
                var firstFactor = JsonConvert(jsonTerm.FirstParam);
                var secondFactor = JsonConvert(jsonTerm.SecondParam);

                switch (jsonTerm.Operation)
                {
                    case Operation.Plus:
                        return firstFactor + secondFactor;
                    case Operation.Minus:
                        return firstFactor - secondFactor;
                    case Operation.Multiply:
                        return firstFactor * secondFactor;
                    case Operation.Power:
                        return firstFactor ^ secondFactor;
                    default:
                        throw (new Exception("Unrecognized operation."));
                }
            }
            else if (jsonTerm.NumberValue != null)
            {
                var newTerm = new List<Term>();
                newTerm.Add(new Term
                {
                    Number = jsonTerm.NumberValue.Value,
                    SymbolsPower = 0
                });
                return new Factor(newTerm);
            }
            else if (jsonTerm.SymbolicValue != null)
            {
                var newTerm = new List<Term>();
                newTerm.Add(new Term
                {
                    Number = 1,
                    Symbol = jsonTerm.SymbolicValue,
                    SymbolsPower = 1
                });
                return new Factor(newTerm);
            }
            else
            {
                throw (new Exception("Unrecognized data type."));
            }
        }

        public static MathMlTerm MathMLConvert(Decomposed decomposed)
        {
            var math = new MathElement();

            decomposed.Factors.ForEach(factor =>
            {
                var mfenced = new MfencedElement();
                factor.Terms.ForEach(term =>
                {
                    var operation = (term.Sign == Sign.Plus) ? "+" : "-";
                    mfenced.Terms.Add(operation);

                    mfenced.Terms.Add(term.Number);  //number

                    if (term.Symbol != null && term.Symbol != default(char))
                    {
                        var insideOperation = "&InvisibleTimes;";

                        mfenced.Terms.Add(insideOperation);  //number *

                        var insideMsup = new MsupElement();

                        var symbolicValue = term.Symbol.Value;

                        var symbolPower = term.SymbolsPower;

                        insideMsup.Terms.Add(symbolicValue);
                        insideMsup.Terms.Add(symbolPower);
                        mfenced.Terms.Add(insideMsup);//x^power
                    }
                });
                math.Terms.Add(mfenced);
            });

            return math;
        }
    }
}
