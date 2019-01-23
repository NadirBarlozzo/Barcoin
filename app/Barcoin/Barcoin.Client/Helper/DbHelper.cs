using Barcoin.Client.Model;
using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;

namespace Barcoin.Client.Helper
{
    public class DbHelper
    {
        private readonly QueryFactory db;

        public DbHelper()
        {
            string options = "datasource=localhost;port=3306;username=root;password=;database=barcoin;SslMode=none";

            MySqlConnection connection = new MySqlConnection(options);

            db = new QueryFactory(connection, new SqlServerCompiler());
        }

        public List<Creditor> Get()
        {
            return db.Query().FromRaw("creditline").SelectRaw("creditorName").Get<Creditor>().ToList();
        }
    }
}
