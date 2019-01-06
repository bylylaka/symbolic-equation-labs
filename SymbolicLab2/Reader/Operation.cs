using System.Runtime.Serialization;

namespace SymbolicLab2.Reader
{
    [DataContract]
    public enum Operation
    {
        Empty,
        [EnumMember(Value = "+")]
        Plus,
        [EnumMember(Value = "-")]
        Minus,
        [EnumMember(Value = "*")]
        Multiply,
        [EnumMember(Value = "/")]
        Divide,
        [EnumMember(Value = "^")]
        Power,
    }
}
