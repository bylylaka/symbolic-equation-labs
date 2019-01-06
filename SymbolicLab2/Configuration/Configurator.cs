using SymbolicLab2.Configuration.ExceptionHandlers;
using System;
using System.IO;
using System.Windows.Forms;

namespace SymbolicLab2.Configuration
{
    class Configurator : IConfigurator
    {
        public override string InputFile => (Directory.GetCurrentDirectory() + "\\input.json");
        public override string OutputFile => Directory.GetCurrentDirectory() + "\\output.xml";

        public override void Configure(IExceptionHandler exceptionHandler)
        {
            AppDomain.CurrentDomain.UnhandledException += exceptionHandler.UnhandledExceptionTrapper;
            Application.EnableVisualStyles();
        }
    }
}
