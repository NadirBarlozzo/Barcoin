 using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CreditManagementTest
{
    public class Program
    {
        public static MySqlConnection databaseConnection;
        public static MySqlCommand command;
        public static MySqlDataReader reader;

        static void Main(string[] args)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=barcoin;SslMode=none";

            databaseConnection = new MySqlConnection(connectionString);

            string query = "SELECT * FROM creditline";

            command = new MySqlCommand(query, databaseConnection)
            {
                CommandTimeout = 10
            };

            List<string[]> creditors = GetResult();

            for (int i = 0; i < creditors.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("ID: " + creditors[i][0]);
                Console.WriteLine("Creditor: " + creditors[i][1] + " " + creditors[i][2]);
                Console.WriteLine("Reason: " + creditors[i][3]);
                Console.WriteLine("Diem Rate: " + creditors[i][4] + " days/year");
                Console.WriteLine("Default Interest Rate: " + creditors[i][5] + "%");

                command.CommandText = "SELECT * FROM transaction WHERE ownerID = " + creditors[i][0] + " ORDER BY date ASC";
                List<string[]> creditorTransactions = GetResult();

                double principalBalance = 0;
                double interestBalance = 0;
                double totalOwed = 0;

                List<double> lastDailyInterests = new List<double>();

                for (int l = 0; l < creditorTransactions.Count; l++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                    Console.WriteLine("\nTransaction nr: " + creditorTransactions[l][0]);
                    Console.WriteLine("Draw Date: " + creditorTransactions[l][1]);
                    Console.WriteLine("\nPrincipal: " + creditorTransactions[l][2]);
                    Console.WriteLine("Interest Rate: " + creditorTransactions[l][3]);

                    int value = Int32.Parse(creditorTransactions[l][2]);
                    int draw = value;
                    
                    double interestRate = Double.Parse(creditorTransactions[l][3]);
                    int diemRate = Int32.Parse(creditors[i][4]);

                    DateTime currentDrawDate = DateTime.Parse(creditorTransactions[l][1]);
                    DateTime lastDrawDate = l == 0 ? currentDrawDate.AddDays(-1) : DateTime.Parse(creditorTransactions[l - 1][1]);

                    double accruedInterest = draw >= 0 ? draw * (interestRate / 100 / diemRate) : 0;
                    double interestPaid = 0;
                    double principalPaid = 0;

                    for (int t = 0; t < lastDailyInterests.Count; t++)
                    {
                        accruedInterest += lastDailyInterests[t] * (currentDrawDate - lastDrawDate).Days;
                    }

                    interestBalance += accruedInterest;

                    if (draw < 0)
                    {
                        double drawRest = 0;

                        if (interestBalance + draw <= 0)
                        {
                            drawRest = draw + interestBalance;
                            interestBalance = 0;

                            principalBalance += drawRest;
                            totalOwed = principalBalance;

                            interestPaid = drawRest - draw;
                            principalPaid = -drawRest;
                        }
                        else
                        {
                            interestBalance += draw;
                            interestPaid = -draw;
                        }
                    }
                    else
                    {
                        principalBalance += draw;
                        totalOwed += draw + accruedInterest;
                    }
 
                    lastDailyInterests.Add(draw * (interestRate / 100 / diemRate));

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("\nPrincipal Balance: " + principalBalance);
                    Console.WriteLine("Accrued Interest: " + accruedInterest);
                    Console.WriteLine("Interest Balance: " + interestBalance);
                    Console.WriteLine("Interest Paid: " + interestPaid);
                    Console.WriteLine("Principal Paid: " + principalPaid);
                    Console.WriteLine("Total Owed: " + totalOwed);
                }

                Console.WriteLine("\n");
            }

            Console.ReadLine();
        }

        public static List<string[]> GetResult()
        {
            List<string[]> result = new List<string[]>();

            try
            {
                databaseConnection.Open();

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) };
                        result.Add(row);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
