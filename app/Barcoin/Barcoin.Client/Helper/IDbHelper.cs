using SqlKata.Execution;

namespace Barcoin.Client.Helper
{
    interface IDbHelper
    {
        QueryFactory GetFactory();
    }
}
