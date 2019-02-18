using SymbolicLab2.Calculator.NumberFactors;
using System;

namespace SymbolicLab2.Calculator.UserAlgorithm
{
    abstract class UserAlgorithmExecutor
    {
        public void ExecuteAlgorithm(dynamic algorithm, IUserAlgorithmStrategyProvider strategyProvider, UserAlgorithmStore store)
        {
            foreach (var step in algorithm)
            {
                var stratgy = strategyProvider.GetStrategy((string)step.Operation);
                stratgy.Execute(step, store);
            }
        }
    }
}
