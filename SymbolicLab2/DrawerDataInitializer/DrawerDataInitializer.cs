using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm;
using SymbolicLab2.Calculator.UserAlgorithm.UserGraphic;
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


        public DrawerModel[] GetDrawerData(
           dynamic algorithm,
           IUserAlgorithmStrategyProvider strategtProvider
       )
        {
            var store = new UserAlgorithmStore();
            var userGrapgicDataInitializer = new UserGraphicDataInitializer();

            dynamic userFunction = algorithm["Function"];
            var drawerFunctionModel = (DrawerModel)userGrapgicDataInitializer.GetGraphicDataFromFunction(userFunction, strategtProvider, store);

            dynamic userSetOfPoints = algorithm["SetOfPoints"];
            var drawerSetOfPointsModel = (DrawerModel)userGrapgicDataInitializer.GetGraphicDataFromSetOfPoints(userSetOfPoints, strategtProvider, store);

            return new DrawerModel[] { drawerFunctionModel, drawerSetOfPointsModel };
        }
    }
}
