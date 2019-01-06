using SymbolicLab2.Calculator;
using SymbolicLab2.Configuration;
using SymbolicLab2.DrawerDataInitializers;
using SymbolicLab2.Drawers;
using SymbolicLab2.Writer;
using JsonReader = SymbolicLab2.Reader.JsonReader;
using System;

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
            var reader = new JsonReader();
            var calculator = new Factorizer();
            var divider = new GornersDividor();
            var writer = new MathMlWriter();
            var drawerDataInitializer = new DrawerDataInitializer();
            var drawer = new Drawer();

            configurator.Configure(exceptionHandler);

            var factors = reader.Read(configurator.InputFile);
            var decomposed = calculator.Execute(factors, divider);
            writer.Write(decomposed, configurator.OutputFile);

            var drawerData = drawerDataInitializer.GetDrawerData(factors, start, end, step);
            drawer.Draw(drawerData);
        }
    }
}
