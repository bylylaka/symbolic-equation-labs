using System.Collections.Generic;

namespace SymbolicLab2.Reader
{
    interface IExpressionReader
    {
        Factor Read(string path);
    }
}
