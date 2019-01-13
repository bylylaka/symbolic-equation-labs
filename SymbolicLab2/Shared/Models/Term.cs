namespace SymbolicLab2
{
    public class Term
    {
        public int Number { get; set; }
        public char? Symbol { get; set; }
        public int SymbolsPower { get; set; }
        public Sign Sign { get; set; }

        public override string ToString()
        {
            var sign = (Sign == Sign.Plus) ? "+" : "-";
            var symbolicPart = (Symbol != default(char) && Symbol != null) ? $"{Symbol}^{SymbolsPower}" : "";
            var termString = string.Concat(sign, Number, symbolicPart);
            return termString;
        }
    }
}
