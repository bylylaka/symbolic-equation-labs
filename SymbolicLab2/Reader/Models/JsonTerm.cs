namespace SymbolicLab2.Reader
{
    public class JsonTerm
    {
        public Operation Operation { get; set; }
        public JsonTerm FirstParam { get; set; }
        public JsonTerm SecondParam { get; set; }
        public double? NumberValue { get; set; }
        public char? SymbolicValue { get; set; }
    }
}