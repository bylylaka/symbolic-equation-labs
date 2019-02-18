using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.NumberFactors.Strategies;
using SymbolicLab2.Calculator.UserAlgorithm.Strategies;
using System.Collections.Generic;

namespace SymbolicLab2.Calculator.NumberFactor
{
    public class UserAlgorithmStrategyProvider : IUserAlgorithmStrategyProvider
    {
        private readonly Dictionary<string, IUserAlgorithmStrategy> strategies;

        public UserAlgorithmStrategyProvider()
        {
            strategies = new Dictionary<string, IUserAlgorithmStrategy>
            {
                {"Append", new AppendUserAlgorithmStrategy() },
                {"Declare", new DeclareUserAlgorithmStrategy() },
                {"If", new IfUserAlgorithmStrategy() },
                {"Return", new ReturnUserAlgortihmStrategy() },
                {"Set", new SetUserAlgorithmStrategy() },
                {"While", new WhileUserAlgortihmStrategy() }
            };
        }

        public IUserAlgorithmStrategy GetStrategy(string operation)
        {
            var strategy = strategies[operation];
            return strategy;
        }
    }
}
