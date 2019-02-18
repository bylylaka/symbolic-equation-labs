using System.Runtime.Serialization;

namespace SymbolicLab2.Calculator.UserAlgorithm.Model
{
    [DataContract]
    enum Condition
    {
        [EnumMember(Value = ">")]
        More,
        [EnumMember(Value = "<")]
        Less,
        [EnumMember(Value = "==")]
        Equals,
        [EnumMember(Value = "!=")]
        NotEquals
    }
}
