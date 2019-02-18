using SymbolicLab2.Configuration.ExceptionHandlers;

namespace SymbolicLab2.Configuration
{
    abstract class IConfigurator
    {
        public abstract string InputExpressionFile { get; }
        public abstract string OutpuExpressiontFile { get; }
        public abstract string InputAlgorithmExpressionFile { get; }
        public abstract string InputGraphicDataSetExpressionFile { get; }

        abstract public void Configure(IExceptionHandler exceptionHandler);
    }
}
