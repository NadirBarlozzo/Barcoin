using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Barcoin.Client.Helper
{
    public class MySqlDatabaseHelper : IDbHelper
    {
        private MySqlConnection databaseConnection;
        private MySqlCommand commandController;
        private MySqlDataReader reader;

        public MySqlDatabaseHelper()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=barcoin;SslMode=none";

            databaseConnection = new MySqlConnection(connectionString);

            commandController = new MySqlCommand("", databaseConnection)
            {
                CommandTimeout = 20
            };
        }

        public List<string[]> ProcessQuery(string query)
        {
             commandController.CommandText = query;

            List<string[]> result = new List<string[]>();

            try
            {
                databaseConnection.Open();

                reader = commandController.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                            reader.GetString(4), reader.GetString(5) };
                        result.Add(row);
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }
}
