using SymbolicLab2.Reader;

namespace SymbolicLab2.Calculator.UserAlgorithm.Model
{
    class IfUserAlgorithmModel: UserAlgorithmModel
    {
        public Condition Condition { get; set; }
        public JsonTerm FirstPart { get; set; }
        public JsonTerm SecondPart { get; set; }
        public dynamic Algorithm { get; set; }
    }
}
