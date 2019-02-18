using SymbolicLab2.Calculator.NumberFactor;
using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm.Model;

namespace SymbolicLab2.Calculator.UserAlgorithm.Strategies
{
    class IfUserAlgorithmStrategy : IUserAlgorithmStrategy
    {
        public void Execute(dynamic jObject, UserAlgorithmStore store)
        {
            var expressionCalculator = new UserExpressionCalculator();
            var numberFactorsExecutor = new NumberFactorsCalculator();

            IfUserAlgorithmModel model = jObject.ToObject<IfUserAlgorithmModel>();
            var firstPart = expressionCalculator.Calculate(model.FirstPart, store);
            var secondPart = expressionCalculator.Calculate(model.SecondPart, store);

            switch (model.Condition)
            {
                case Condition.More:
                    if (firstPart > secondPart)
                    {
                        numberFactorsExecutor.ExecuteAlgorithm(model.Algorithm, new UserAlgorithmStrategyProvider(), store);
                    }
                    break;
                case Condition.Less:
                    if (firstPart < secondPart)
                    {
                        numberFactorsExecutor.ExecuteAlgorithm(model.Algorithm, new UserAlgorithmStrategyProvider(), store);
                    }
                    break;
                case Condition.Equals:
                    if (firstPart == secondPart)
                    {
                        numberFactorsExecutor.ExecuteAlgorithm(model.Algorithm, new UserAlgorithmStrategyProvider(), store);
                    }
                    break;
                case Condition.NotEquals:
                    if (firstPart != secondPart)
                    {
                        numberFactorsExecutor.ExecuteAlgorithm(model.Algorithm, new UserAlgorithmStrategyProvider(), store);
                    }
                    break;
            }
        }
    }
}
