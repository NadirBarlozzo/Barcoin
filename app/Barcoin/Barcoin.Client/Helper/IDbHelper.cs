using System.Collections.Generic;

namespace Barcoin.Client.Helper
{
    interface IDbHelper
    {
        List<string[]> ProcessQuery(string query);
    }
}
