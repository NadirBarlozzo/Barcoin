using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows; 

namespace Barcoin.Client.Helper
{
    public class SQLiteDatabaseHelper : IDbHelper
    {
        private SQLiteConnection databaseConnection;                     

        public SQLiteDatabaseHelper()
        {
            string connectionString = "Data Source="+ Environment.CurrentDirectory +"\\barcoin.sqlite; Version=3;";

            databaseConnection = new SQLiteConnection(connectionString);
        }

        public List<string[]> ProcessQuery(string query)
        {
            SQLiteCommand commandController = databaseConnection.CreateCommand();
            commandController.CommandText = query;

            List<string[]> result = new List<string[]>();

            try
            {
                databaseConnection.Open();

                SQLiteDataReader reader = commandController.ExecuteReader();

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
