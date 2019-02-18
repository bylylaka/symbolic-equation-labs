using System.Collections.Generic;

namespace SymbolicLab2.Calculator.NumberFactors
{
    public class UserAlgorithmStore
    {
        public UserAlgorithmStore()
        {
            NumverVariables = new Dictionary<string, double>();
            ListVariables = new Dictionary<string, List<double>>();
        }

        public Dictionary<string, double> NumverVariables { get; set; }
        public Dictionary<string, List<double>> ListVariables { get; set; }
        public string ReturnVariable { get; set; }
    }
}
