using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Reader;
using System;

namespace SymbolicLab2.Calculator.UserAlgorithm
{
    class UserExpressionCalculator
    {
        public double Calculate(JsonTerm expression, UserAlgorithmStore store)
        {
            if (expression.Operation != Operation.Empty)
            {
                var firstFactor = Calculate(expression.FirstParam, store);
                var secondFactor = Calculate(expression.SecondParam, store);

                switch (expression.Operation)
                {
                    case Operation.Plus:
                        return firstFactor + secondFactor;
                    case Operation.Minus:
                        return firstFactor - secondFactor;
                    case Operation.Multiply:
                        return firstFactor * secondFactor;
                    case Operation.Divide:
                        return firstFactor / secondFactor;
                    case Operation.Power:
                        return Math.Pow(firstFactor,secondFactor);
                    case Operation.Mod:
                        return firstFactor % secondFactor;
                    default:
                        throw (new Exception("Unrecognized operation."));
                }
            }
            else if (expression.NumberValue != null)
            {
                return expression.NumberValue.Value;
            }
            else if (expression.SymbolicValue != null)
            {
                return store.NumverVariables[expression.SymbolicValue.Value.ToString()];
            }
            else
            {
                throw (new Exception("Unrecognized operation."));
            }
        }
    }
}
