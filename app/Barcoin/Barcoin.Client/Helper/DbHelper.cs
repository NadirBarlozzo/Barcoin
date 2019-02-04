using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Barcoin.Client.Helper
{
    public class DbHelper : IDbHelper
    {
        private readonly QueryFactory db;

        public DbHelper()
        {
            string options = "Host=localhost;Port=3306;User=root;Password=;Database=barcoinv2;SslMode=None";

            MySqlConnection connection = new MySqlConnection(options);
            connection.Open();

            db = new QueryFactory(connection, new MySqlCompiler());
        }

        public QueryFactory GetFactory()
        {
            return db;
        }
    }
}
