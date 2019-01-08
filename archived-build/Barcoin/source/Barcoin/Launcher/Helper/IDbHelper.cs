using System.Collections.Generic;

namespace Launcher.Helper
{
    interface IDbHelper
    {
        List<string[]> ProcessQuery(string query);
    }
}
