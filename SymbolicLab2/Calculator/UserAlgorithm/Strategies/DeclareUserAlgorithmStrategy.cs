using SymbolicLab2.Calculator.NumberFactors;
using SymbolicLab2.Calculator.UserAlgorithm.Model;
using System.Collections.Generic;

namespace SymbolicLab2.Calculator.UserAlgorithm.Strategies
{
    class DeclareUserAlgorithmStrategy : IUserAlgorithmStrategy
    {
        public void Execute(dynamic jObject, UserAlgorithmStore store)
        {
            DeclareUserAlgorithmModel model = jObject.ToObject<DeclareUserAlgorithmModel>();

            switch (model.Type)
            {
                case VatiableType.number:
                    {
                        store.NumverVariables.Add(model.Variable, 0);
                        break;
                    }
                case VatiableType.list:
                    {
                        store.ListVariables.Add(model.Variable, new List<double>());
                        break;
                    }
            }
        }
    }
}