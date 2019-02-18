using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm.UserGraphic.Model;
using SymbolicLab2.Drawers;
using System;
using System.Linq;

namespace SymbolicLab2.Calculator.UserAlgorithm.UserGraphic
{
    class UserGraphicDataInitializer : UserAlgorithmExecutor
    {
        public DrawerModel GetGraphicDataFromFunction(dynamic algorithm, IUserAlgorithmStrategyProvider strategyProvider, UserAlgorithmStore store)
        {
            var drawerModel = new DrawerModel();

            if (algorithm == null)
            {
                return drawerModel;
            }

            ExecuteAlgorithm(algorithm.Algorithm, strategyProvider, store);
            var returnVariable = store.ReturnVariable;

            var xs = store.ListVariables["x"];
            var ys = store.ListVariables["y"];

            if (xs.Count != ys.Count)
            {
                throw new Exception("Mistake in Graphic builder algorithm");
            }

            for (var i = 0; i < xs.Count; i++)
            {
                drawerModel.AddData(xs[i], ys[i]);
            }

            return drawerModel;
        }






        public DrawerModel GetGraphicDataFromSetOfPoints(dynamic setOfPoints, IUserAlgorithmStrategyProvider strategyProvider, UserAlgorithmStore store)
        {
            var drawerModel = new DrawerModel();

            if (setOfPoints == null)
            {
                return drawerModel;
            }

            var points = setOfPoints.ToObject<PointModel[]>();
            (points as PointModel[]).ToList().ForEach(point =>
            {
                drawerModel.AddData(point.X, point.Y);
            });

            return drawerModel;
        }
    }
}
