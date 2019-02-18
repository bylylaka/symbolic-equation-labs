using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm.Model;

namespace SymbolicLab2.Calculator.UserAlgorithm.Strategies
{
    class ReturnUserAlgortihmStrategy : IUserAlgorithmStrategy
    {
        public void Execute(dynamic jObject, UserAlgorithmStore store)
        {
            ReturnUserAlgorithmModel model = jObject.ToObject<ReturnUserAlgorithmModel>();
            store.ReturnVariable = model.Variable;
        }
    }
}