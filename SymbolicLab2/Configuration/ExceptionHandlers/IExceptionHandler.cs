using System;

namespace SymbolicLab2.Configuration.ExceptionHandlers
{
    interface IExceptionHandler
    {
        void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e);
    }
}
