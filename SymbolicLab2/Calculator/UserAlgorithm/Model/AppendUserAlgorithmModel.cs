using SymbolicLab2.Reader;

namespace SymbolicLab2.Calculator.UserAlgorithm.Model
{
    class AppendUserAlgorithmModel : UserAlgorithmModel
    {
        public string Variable { get; set; }
        public JsonTerm Value { get; set; }
    }
}
