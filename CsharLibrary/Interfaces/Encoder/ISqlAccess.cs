using System.Collections.Generic;
using System.Data;

namespace CsharLibrary.Encoder
{
    internal interface ISqlAccess
    {
        string db { get; }
        Dictionary<int, string> AddElementToDatabase(DataTable table);
        DataTable GetElementToDatabase(int capacity);
    }
}