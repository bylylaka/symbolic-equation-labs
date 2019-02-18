using SymbolicLab2.Reader;

namespace SymbolicLab2.Calculator.UserAlgorithm.Model
{
    public class SetUserAlgorithmModel: UserAlgorithmModel
    {
        public string Variable { get; set; }
        public JsonTerm Value { get; set; }
    }
}
