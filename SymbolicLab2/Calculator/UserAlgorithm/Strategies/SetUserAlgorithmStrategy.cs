using SymbolicLab2.Calculator.UserAlgorithm;
using SymbolicLab2.Calculator.UserAlgorithm.Model;

namespace SymbolicLab2.Calculator.NumberFactors.Strategies
{
    public class SetUserAlgorithmStrategy : IUserAlgorithmStrategy
    {
        public void Execute(dynamic jObject, UserAlgorithmStore store)
        {
            var expressionCalculator = new UserExpressionCalculator();

            SetUserAlgorithmModel model = jObject.ToObject<SetUserAlgorithmModel>();
            var value = expressionCalculator.Calculate(model.Value, store);

            store.NumverVariables[model.Variable] = value;
        }
    }
}
