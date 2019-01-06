namespace SymbolicLab2.Calculator
{
    interface ICalculator
    {
        Decomposed Execute(Factor factors, IDivider divider);
    }
}
