using SymbolicLab2.Configuration.ExceptionHandlers;
using System;
using System.IO;
using System.Windows.Forms;

namespace SymbolicLab2.Configuration
{
    class Configurator : IConfigurator
    {
        public override string InputExpressionFile => Path.Combine(Directory.GetCurrentDirectory(), "inputExpression.json");
        public override string InputAlgorithmExpressionFile => Path.Combine(Directory.GetCurrentDirectory(), "inputAlgorithm.json");
        public override string InputGraphicDataSetExpressionFile => Path.Combine(Directory.GetCurrentDirectory(), "inputGraphicDataSet.json");
        public override string OutpuExpressiontFile => Path.Combine(Directory.GetCurrentDirectory(), "outputExpression.xml");

        public override void Configure(IExceptionHandler exceptionHandler)
        {
            //AppDomain.CurrentDomain.UnhandledException += exceptionHandler.UnhandledExceptionTrapper;
            //Application.EnableVisualStyles();
        }
    }
}
