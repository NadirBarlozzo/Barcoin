using SqlKata.Execution;

namespace Barcoin.Blockchain.Helper
{
    interface IDbHelper
    {
        QueryFactory GetFactory();
    }
}
