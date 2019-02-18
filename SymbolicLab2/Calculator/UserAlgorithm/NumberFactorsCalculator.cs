using SymbolicLab2.Calculator.NumberFactors;
using System.Collections.Generic;

namespace SymbolicLab2.Calculator.UserAlgorithm
{
    class NumberFactorsCalculator: UserAlgorithmExecutor
    {
        public List<double> GetNumberFactors(int number, dynamic algorithm, IUserAlgorithmStrategyProvider strategyProvider, UserAlgorithmStore store)
        {
            store.NumverVariables["n"] = number;

            ExecuteAlgorithm(algorithm.Algorithm, strategyProvider, store);
            var returnVariable = store.ReturnVariable;

            var result = store.ListVariables[store.ReturnVariable];
            return result;
        }
    }
}
