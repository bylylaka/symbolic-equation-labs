namespace SymbolicLab2.Calculator.NumberFactors
{
    public interface IUserAlgorithmStrategyProvider
    {
        IUserAlgorithmStrategy GetStrategy(string operation);
    }
}
