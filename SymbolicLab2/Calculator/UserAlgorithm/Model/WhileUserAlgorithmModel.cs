using SymbolicLab2.Reader;

namespace SymbolicLab2.Calculator.UserAlgorithm.Model
{
    class WhileUserAlgorithmModel : UserAlgorithmModel
    {
        public Condition Condition { get; set; }
        public JsonTerm FirstPart { get; set; }
        public JsonTerm SecondPart { get; set; }
        public dynamic Algorithm { get; set; }
    }
}
