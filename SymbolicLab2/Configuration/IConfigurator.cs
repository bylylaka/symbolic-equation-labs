using SymbolicLab2.Configuration.ExceptionHandlers;

namespace SymbolicLab2.Configuration
{   
    abstract class IConfigurator
    {
        public abstract string InputFile { get; }
        public abstract string OutputFile { get; }

        abstract public void Configure(IExceptionHandler exceptionHandler);
    }
}
