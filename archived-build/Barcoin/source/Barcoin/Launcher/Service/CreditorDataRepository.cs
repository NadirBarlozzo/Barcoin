using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using Launcher.Enum;
using Launcher.Helper;
using Launcher.Model;
using Launcher.Static;

namespace Launcher.Service
{
    public class CreditorDataRepository : ICreditorDataRepository
    {
        private readonly IDbHelper helper;

        public CreditorDataRepository()
        {
            if (Settings.Mode == Modality.Local)
            {
                helper = new SQLiteDatabaseHelper();
            }
            else {
                helper = new MySqlDatabaseHelper();
            }
        }

        public void Add(Creditor item)
        {
            int lastId = 0;
            string query = "";

            if (Settings.Mode == Modality.Local)
            {
                query = $"SELECT * FROM `creditline` ORDER BY" +
                    $" `creditline`.`creditID` DESC LIMIT 1";

                lastId = int.Parse(helper.ProcessQuery(query)[0][0]);

                query = $"INSERT INTO `creditline` (`creditID`," +
                    $"`creditorName`, `creditorSurname`, `description`, `diemRate`, `defaultInterestRate`) VALUES" +
                    $" ('{lastId+1}', '{item.CreditorName}', '{item.CreditorSurname}', '{item.Description}', '{item.DiemRate}'," +
                    $" '{item.DefaultInterestRate}')";
            }
            else
            {
                query = $"INSERT INTO `creditline` (" +
                    $"`creditorName`, `creditorSurname`, `description`, `diemRate`, `defaultInterestRate`) VALUES" +
                    $" ('{item.CreditorName}', '{item.CreditorSurname}', '{item.Description}', '{item.DiemRate}'," +
                    $" '{item.DefaultInterestRate}')";
            }


            List<string[]> result = helper.ProcessQuery(query);
        }

        public void Delete(Creditor item)
        {
            throw new NotImplementedException();
        }

        public Creditor Get(int id)
        {
            string query = "SELECT * FROM creditline WHERE creditID = " + id;

            List<string[]> result = helper.ProcessQuery(query);

            Creditor c = new Creditor()
            {
                CreditLineID = int.Parse(result[0][0]),
                CreditorName = result[0][1],
                CreditorSurname = result[0][2],
                Description = result[0][3],
                DiemRate = int.Parse(result[0][4]),
                DefaultInterestRate = double.Parse(result[0][5])
            };

            return c;
        }

        public List<Creditor> Get()
        {
            string query = "SELECT * FROM creditline";

            List<string[]> result = helper.ProcessQuery(query);
            List<Creditor> creditors = new List<Creditor>();

            for (int i = 0; i < result.Count; i++)
            {
                Creditor c = new Creditor()
                {
                    CreditLineID = int.Parse(result[i][0]),
                    CreditorName = result[i][1],
                    CreditorSurname = result[i][2],
                    Description = result[i][3],
                    DiemRate = int.Parse(result[i][4]),
                    DefaultInterestRate = double.Parse(result[i][5])
                };

                creditors.Add(c);
            }

            return creditors;
        }
    }
}
