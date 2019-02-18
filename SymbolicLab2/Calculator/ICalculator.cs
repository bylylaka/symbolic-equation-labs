using SymbolicLab2.Calculator.NumberFactors;

namespace SymbolicLab2.Calculator
{
    interface ICalculator
    {
        Decomposed Execute(
            Factor factors,
            IDivider divider,
            dynamic algorithm,
            IUserAlgorithmStrategyProvider strategtProvider
        );
    }
}
