using System.Collections.Generic;

namespace SymbolicLab2.Reader
{
    interface IReader
    {
        Factor Read(string path);
    }
}
