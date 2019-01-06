using SymbolicLab2.Configuration.ExceptionHandlers;
using System;

namespace SymbolicLab2.Configuration
{
    public class ExceptionHandler : IExceptionHandler
    {
        public void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception)args.ExceptionObject;
            Console.WriteLine(e.Message);
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
