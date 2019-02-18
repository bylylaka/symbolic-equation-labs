using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm.Model;

namespace SymbolicLab2.Calculator.UserAlgorithm.Strategies
{
    class AppendUserAlgorithmStrategy : IUserAlgorithmStrategy
    {
        public void Execute(dynamic jObject, UserAlgorithmStore store)
        {
            var expressionCalculator = new UserExpressionCalculator();

            AppendUserAlgorithmModel model = jObject.ToObject<AppendUserAlgorithmModel>();
            var value = expressionCalculator.Calculate(model.Value, store);

            store.ListVariables[model.Variable].Add(value);
        }
    }   
}