using SymbolicLab2.Drawers;
using SymbolicLab2.DrowerDataInitializers;
using System;

namespace SymbolicLab2.DrawerDataInitializers
{
    public class DrawerDataInitializer : IDrowerDataInitializer
    {
        public DrawerModel GetDrawerData(Factor factors, double start, double end, double step)
        {
            var drawModel = new DrawerModel();

            for (double x = start; x <= end; x += step)
            {
                double y = 0;

                factors.Terms.ForEach(term =>
               {
                   if (term.Symbol != default(char))
                   {
                       y += ((term.Sign == Sign.Plus) ? term.Number : -term.Number) * Math.Pow(x, term.SymbolsPower);
                   }
                   else
                   {
                       y += (term.Sign == Sign.Plus) ? term.Number : -term.Number;
                   }
               });

                drawModel.AddData(x, y);
            }

            return drawModel;
        }
    }
}
