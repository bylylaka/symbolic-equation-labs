using SymbolicLab2.Calculator;
using SymbolicLab2.Configuration;
using SymbolicLab2.DrawerDataInitializers;
using SymbolicLab2.Drawers;
using SymbolicLab2.Writer;
using JsonExpressionReader = SymbolicLab2.Reader.JsonExpressionReader;
using System;
using SymbolicLab2.Reader;
using SymbolicLab2.Calculator.NumberFactor;

namespace SymbolicLab2
{
    class Program
    {
        private static readonly float start = -20;
        private static readonly float end = 20;
        private static readonly float step = 0.5f;

        [STAThread]
        static void Main(string[] args)
        {
            var configurator = new Configurator();
            var exceptionHandler = new ExceptionHandler();
            var expressionReader = new JsonExpressionReader();
            var algorithmReader = new JsonAlgorithmReader();
            var calculator = new Factorizer();
            var divider = new GornersDividor();
            var writer = new MathMlWriter();
            var drawerDataInitializer = new DrawerDataInitializer();
            var drawer = new Drawer();
            var userAlgorithmStrategyProvider = new UserAlgorithmStrategyProvider();

            configurator.Configure(exceptionHandler);

            var factors = expressionReader.Read(configurator.InputExpressionFile);
            var algorithm = algorithmReader.Read(configurator.InputAlgorithmExpressionFile);
            var grephicDataSet = algorithmReader.Read(configurator.InputGraphicDataSetExpressionFile);
            
            var decomposed = calculator.Execute(factors, divider, algorithm, userAlgorithmStrategyProvider);
            writer.Write(decomposed, configurator.OutpuExpressiontFile);

            var drawerData = drawerDataInitializer.GetDrawerData(grephicDataSet, userAlgorithmStrategyProvider);

            //var drawerData = drawerDataInitializer.GetDrawerData(factors, start, end, step);
            drawer.Draw(drawerData);
        }
    }
}
