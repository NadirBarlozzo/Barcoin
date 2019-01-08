using System;

namespace Launcher.Model
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public DateTime RawDate { get; set; }

        public int Principal { get; set; }

        public double InterestRate { get; set; }

        public string Description { get; set; }
    }
}
