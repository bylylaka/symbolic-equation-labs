using System.Collections.Generic;

namespace SymbolicLab2.Drawers
{
    public class DrawerModel
    {
        public List<double> X { get; }
        public List<double> Y { get; }

        public DrawerModel()
        {
            X = new List<double>();
            Y = new List<double>();
        }

        public void AddData(double x, double y)
        {
            this.X.Add(x);
            this.Y.Add(y);
        }
    }
}
